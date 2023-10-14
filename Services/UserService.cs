
using AutoMapper;

namespace picpay;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

     public async Task<List<UserDTO>> GetAll()
    {
        var users = await _repository.GetAll();
        return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
    }

    public Guid Create(UserCreateDTO userCreateDTO)
    {
        throw new NotImplementedException();
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
