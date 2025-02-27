using Microsoft.EntityFrameworkCore;

namespace API.DAL;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task SetUser(User user)
    {   
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByLogin(string login)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        return result;
    }

    public async Task<string?> GetHashPasswordByLogin(string login)
    {
        var result = await GetUserByLogin(login);
        return result?.HashPassword;
    }
}