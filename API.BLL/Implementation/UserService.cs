using API.DAL;
using BCrypt.Net;

namespace API.BLL;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<string?> Login(User user)
    {
        var storedHash = await _userRepository.GetHashPasswordByLogin(user.Login);
        // Перевіряємо, чи є такий користувач у базі
        if (string.IsNullOrEmpty(storedHash))
        {
            return null; // Повертаємо null, щоб контролер повернув 401 Unauthorized
        }
        
        var success = await VerifyPassword(user.Login, user.HashPassword);
        if (success == false)
        {
            return null;
        }

        return "Ok";
    }

    public async Task Register(User user)
    {
        var result = await _userRepository.GetUserByLogin(user.Login);
        try
        {
            if (result != null)
            {
                throw new Exception("Fail with registration!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

        var userHash = new User
        {
            Id = user.Id,
            Login = user.Login,
            HashPassword = GenerateHashPassword(user.HashPassword)
        };
            
        await _userRepository.SetUser(userHash);
    }

    public async Task<bool?> VerifyPassword(string login, string inputPassword)
    {
        var hashPassword = await _userRepository.GetHashPasswordByLogin(login);
        
        return BCrypt.Net.BCrypt.Verify(inputPassword, hashPassword);
    }

    public string GenerateHashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}