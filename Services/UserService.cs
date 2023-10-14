
using AutoMapper;

namespace picpay;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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

        var userId = _repository.Create(user);
        await _unitOfWork.Save();

        return userId;
    }

    public Task Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetById()
    {
        throw new NotImplementedException();
    }

    public void Update(UserUpdateDTO userUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
