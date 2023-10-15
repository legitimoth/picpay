
using Microsoft.EntityFrameworkCore;

namespace picpay;

public class TransactionRepository : ITransactionRepository
{
    private readonly PicPayDbContext _context;

    public TransactionRepository(PicPayDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Create(Transaction transaction)
    {
        var id = await _context.AddAsync(transaction);
        return transaction.Id;
    }

    public async Task<List<Transaction>> GetByUserId(Guid id)
    {
        return await _context.Transactions
            .Include(t => t.Payer)
            .Include(t => t.Payee)
            .Where(t => t.PayeeId == id || t.PayerId == id)
            .ToListAsync();
    }
}
