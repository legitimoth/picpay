namespace picpay;

public interface IUserService
{
    public Task<List<UserDTO>> GetAll();
    public Task<UserDTO> GetById();
    public Guid Create(UserCreateDTO userCreateDTO);
    public void Update(UserUpdateDTO userUpdateDTO);
    public Task Delete(Guid Id);
}
