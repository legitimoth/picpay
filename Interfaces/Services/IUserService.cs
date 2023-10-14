namespace picpay;

public interface IUserService
{
    public Task<List<UserDTO>> GetAll();
    public Task<UserDTO> GetById(Guid id);
    public Task<Guid> Create(UserCreateDTO userCreateDTO);
    public Task Update(Guid id, UserUpdateDTO userUpdateDTO);
    public Task Delete(Guid id);
}
