using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using TubesKPL_Kelompok_2.Repositories;

public class AdminService
{
    private readonly GameStateMachine gameStateMachine;
    private readonly AdminRepository adminRepository;
    private readonly UserRepository userRepository;
    private readonly WalletRepository walletRepository;

    public AdminService()
    {
        gameStateMachine = new GameStateMachine();
        adminRepository = new AdminRepository();
        userRepository = new UserRepository();
        walletRepository = new WalletRepository();
    }

    public string AddGame(string name, int price)
    {
        Game newGame = new Game
        {
            Id = 1,
            Name = name.Trim(),
            Price = price,
            Status = GameStatus.NotOwned
        };

        GameValidator validator = new GameValidator();
        ValidationResult result = validator.Validate(newGame);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        int newId = adminRepository.AddGame(newGame.Name, newGame.Price);
        return $"Game berhasil ditambahkan ke database dengan ID {newId}";
    }

    public List<Game> GetAllGames()
    {
        return adminRepository.GetAllGames();
    }

    public Game GetGameById(int gameId)
    {
        return adminRepository.GetGameById(gameId);
    }

    public string EditGame(int gameId, string name, int price)
    {
        try
        {
            Game updatedGame = new Game
            {
                Id = gameId,
                Name = name.Trim(),
                Price = price,
                Status = GameStatus.NotOwned
            };

            GameValidator validator = new GameValidator();
            ValidationResult result = validator.Validate(updatedGame);

            if (!result.IsValid)
                return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

            adminRepository.UpdateGame(updatedGame.Id, updatedGame.Name, updatedGame.Price);
            return $"Game dengan ID {gameId} berhasil diubah";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string DeleteGame(int gameId)
    {
        try
        {
            Game game = adminRepository.GetGameById(gameId);
            adminRepository.DeleteGame(gameId);
            return $"Game {game.Name} berhasil dihapus";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public List<User> GetAllUsers()
    {
        return adminRepository.GetAllUsers();
    }

    public List<Game> GetPendingRefundGames()
    {
        return adminRepository.GetPendingRefundGames();
    }

    public Game GetPendingRefundGameById(int gameId)
    {
        return adminRepository.GetPendingRefundGameByGameId(gameId);
    }

    public string ProcessRefund(int userId, int gameId, bool approve)
    {
        try
        {
            if (approve)
            {
                adminRepository.ApproveRefund(userId, gameId);
                return "Refund disetujui dan saldo user dikembalikan.";
            }
            else
            {
                adminRepository.RejectRefund(userId, gameId);
                return "Refund ditolak.";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    // Dipakai oleh API (menggunakan userId)
    public string BanWallet(int userId)
    {
        try
        {
            User user = userRepository.GetUserById(userId);

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak bisa dibanned";

            walletRepository.UpdateWalletState(userId, "Banned");
            return $"Wallet user {user.Username} berhasil dibanned";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string UnbanWallet(int userId)
    {
        try
        {
            User user = userRepository.GetUserById(userId);

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak perlu di-unban";

            walletRepository.UpdateWalletState(userId, "Active");
            return $"Wallet user {user.Username} berhasil di-unban dan aktif kembali";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    // Dipakai oleh UI konsol (menggunakan username)
    public string BanWalletByUsername(string username)
    {
        try
        {
            User user = adminRepository.GetUserByUsername(username.Trim());

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak bisa dibanned";

            walletRepository.UpdateWalletState(user.Id, "Banned");
            return $"Wallet user {user.Username} berhasil dibanned";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string UnbanWalletByUsername(string username)
    {
        try
        {
            User user = adminRepository.GetUserByUsername(username.Trim());

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak perlu di-unban";

            walletRepository.UpdateWalletState(user.Id, "Active");
            return $"Wallet user {user.Username} berhasil di-unban dan aktif kembali";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
