using API.DAL;
using Microsoft.AspNetCore.Identity.Data;

namespace API.BLL;

public interface IUserService
{
    public Task<string?> Login(User user);
    public Task Register(User user);

    protected Task<bool?> VerifyPassword(string login, string password);
    protected string GenerateHashPassword(string password);
}