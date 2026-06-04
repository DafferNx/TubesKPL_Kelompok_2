using System;
using TubesKPL_Kelompok_2.Repositories;

public class AuthService
{
    private readonly AuthRepository authRepository;
    private readonly UserRepository userRepository;

    public AuthService()
    {
        authRepository = new AuthRepository();
        userRepository = new UserRepository();
    }

    public User Login(string username, string password)
    {
        return authRepository.Login(username, password);
    }

    public User GetUserById(int userId)
    {
        return userRepository.GetUserById(userId);
    }

    public string ActivateWallet(User user)
    {
        string message = user.Wallet.ChangeState(WalletAction.Activate);
        userRepository.UpdateWallet(user);
        return message;
    }

    public string DeactivateWallet(User user)
    {
        string message = user.Wallet.ChangeState(WalletAction.Deactivate);
        userRepository.UpdateWallet(user);
        return message;
    }

    public string TopUpWallet(User user, int amount)
    {
        string message = user.Wallet.TopUp(amount);
        userRepository.UpdateWallet(user);
        return message;
    }
}
