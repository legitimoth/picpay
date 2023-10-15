namespace picpay;

public interface ITransactionRepository
{
    public Task<List<Transaction>> GetByUserId(Guid id);
    public Task<Guid> Create(Transaction transaction);
}
