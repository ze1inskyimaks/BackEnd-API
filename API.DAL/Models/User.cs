namespace API.DAL;

public class User
{
    public uint Id { get; set; }
    public string Login { get; set; }
    public string HashPassword { get; set; }
}