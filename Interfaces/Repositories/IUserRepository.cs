namespace picpay;

public interface IUserRepository
{
    public Task<List<User>> GetAll();
    public Task<User> GetById();
    public Guid Create();
    public void Update(User user);
    public Task Delete(Guid Id);
}
