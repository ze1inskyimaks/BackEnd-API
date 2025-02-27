namespace API.DAL;

public interface IUserRepository
{
    public Task SetUser(User user);
    public Task<User?> GetUserByLogin(string login);
    public Task<string?> GetHashPasswordByLogin(string login);
}