
namespace picpay;

public class UnitOfWork : IUnitOfWork
{
    private readonly PicPayDbContext _context;

    public UnitOfWork(PicPayDbContext context)
    {
        _context = context;
    }
    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
