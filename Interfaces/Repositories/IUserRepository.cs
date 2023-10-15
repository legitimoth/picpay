namespace picpay;

public interface IUserRepository
{
    public Task<List<User>> GetAll();
    public Task<User?> GetById(Guid id);
    public Task<Guid> Create(User user);
    public void Update(User user);
    public void Delete(User user);
    public Task<bool> Exists(User user);
}
