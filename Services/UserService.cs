
namespace picpay;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

     public async Task<List<UserDTO>> GetAll()
    {
        throw new NotImplementedException();
        //return await _repository.GetAll();
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
