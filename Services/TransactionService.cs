
using AutoMapper;

namespace picpay;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public TransactionService(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Guid> Create(Guid payerId, TransferDTO transferDTO)
    {
        return await _repository.Create(new(
            payerId,
            transferDTO.PayeeId,
            transferDTO.Value
        ));
    }

    public async Task<List<TransactionDTO>> GetByUserId(Guid id)
    {
        var transactions = await _repository.GetByUserId(id);

        return transactions.Select(t =>
            _mapper.Map<TransactionDTO>(t, opt => opt.Items["id"] = id)
        ).ToList();
    }
}
