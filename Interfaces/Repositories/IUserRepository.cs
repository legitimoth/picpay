namespace picpay;

public interface IUserRepository
{
    public Task<List<User>> GetAll();
    public Task<User> GetById();
    public Guid Create(User user);
    public void Update(User user);
    public Task Delete(Guid Id);
    public Task<bool> Exists(User user);
}
