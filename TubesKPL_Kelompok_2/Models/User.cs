public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public Wallet Wallet { get; set; } = new Wallet();

    public User() { }

    public User(string username, UserRole role)
    {
        Username = username;
        Role = role;
        Wallet = new Wallet();
    }

    public User(int id, string username, string password, UserRole role, Wallet wallet)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        Wallet = wallet;
    }
}
