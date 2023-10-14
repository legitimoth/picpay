namespace picpay;

public interface IUnitOfWork
{
    public Task Save();
}
