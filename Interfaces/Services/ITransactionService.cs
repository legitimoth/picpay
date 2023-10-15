namespace picpay;

public interface ITransactionService
{
    public Task<List<TransactionDTO>> GetByUserId(Guid id);
    public Task<Guid> Create(Guid PayerId, TransferDTO transferDTO);
}
