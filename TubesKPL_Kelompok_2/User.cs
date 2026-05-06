public class User
{
    public string Username { get; set; }
    public UserRole Role { get; set; }
    public Wallet Wallet { get; set; }

    public User(string username, UserRole role)
    {
        Username = username;
        Role = role;
        Wallet = new Wallet();
    }
}
