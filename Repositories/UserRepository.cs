
using Microsoft.EntityFrameworkCore;

namespace picpay;

public class UserRepository : IUserRepository
{
    private readonly PicPayDbContext _context;

    public UserRepository(PicPayDbContext context)
    {
        _context = context;
    }


    public Task<List<User>> GetAll()
    {
        return _context.Users.Where(u => u.Active).ToListAsync();
    }

    public Guid Create(User user)
    {
        _context.Add(user);
        return user.Id;
    }

    public Task Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById()
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Exists(User user)
    {
        var userDb = await _context.Users.FirstOrDefaultAsync(u =>
            u.Document == user.Document || u.Email == user.Email
        );

        return userDb != null;
    }
}
