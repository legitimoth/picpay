
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
}
