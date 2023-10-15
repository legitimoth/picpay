
using AutoMapper;

namespace picpay;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionService _transactionService;
    private readonly IPaymentService _paymentService;

    public UserService(
        IUserRepository repository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ITransactionService transactionService,
        IPaymentService paymentService
    )
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _transactionService = transactionService;
        _paymentService = paymentService;
    }

     public async Task<List<UserDTO>> GetAll()
    {
        var users = await _repository.GetAll();
        return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
    }

    public async Task<Guid> Create(UserCreateDTO userCreateDTO)
    {
        var user = _mapper.Map<User>(userCreateDTO);

        if (await _repository.Exists(user))
        {
            throw new Exception("Já existe usuário cadastrado para o email ou CNPJ/CPF informado!");
        }

        var userId = await _repository.Create(user);
        await _unitOfWork.Save();

        return userId;
    }

    public async Task Delete(Guid id)
    {
        var userDb = await _getById(id);
        _repository.Delete(userDb);

        await _unitOfWork.Save();
    }

    public async Task<UserDTO> GetById(Guid id)
    {
        var userDb = await _getById(id);

        return _mapper.Map<UserDTO>(userDb);
    }

    public async Task Update(Guid id, UserUpdateDTO userUpdateDTO)
    {
        var userDb = await _getById(id);
        _mapper.Map(userUpdateDTO, userDb);
        _repository.Update(userDb);

        await _unitOfWork.Save();
    }

    private async Task<User>_getById(Guid id) => await _repository.GetById(id) ??
        throw new Exception("Usuário não encontrado!");

    public async Task<Guid> Transfer(Guid payerId, TransferDTO transferDTO)
    {
        var payer = await _getById(payerId) ;

        if(payer.Type == UserType.Retailer)
        {
            throw new Exception("Lojistas não podem realizar transferências!");
        }

        if(payer.Wallet < transferDTO.Value)
        {
            throw new Exception("Você não tem saldo suficiente para essa transferência!");
        }

        payer.Pay(transferDTO.Value);
        var payee = await _getById(transferDTO.PayeeId);
        payee.Receiver(transferDTO.Value);

        var transactionId = await _transactionService.Create(
            payerId,
            transferDTO
        );

        if(!await _paymentService.Verify())
        {
            throw new Exception("Transação recusada pelo serviço de pagamento!");
        }

        await _unitOfWork.Save();

        return transactionId;
    }
}
