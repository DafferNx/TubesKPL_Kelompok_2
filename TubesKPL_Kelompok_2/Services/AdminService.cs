using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using TubesKPL_Kelompok_2.Database;
public class AdminService
{
    private readonly GameStateMachine gameStateMachine;

    public AdminService()
    {
        gameStateMachine = new GameStateMachine();
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

        int newId = DatabaseHelper.AddGame(newGame.Name, newGame.Price);
        return $"Game berhasil ditambahkan ke database dengan ID {newId}";
    }

    public List<Game> GetAllGames()
    {
        return DatabaseHelper.GetAllGames();
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

            DatabaseHelper.UpdateGame(updatedGame.Id, updatedGame.Name, updatedGame.Price);
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
            Game game = DatabaseHelper.GetGameById(gameId);
            DatabaseHelper.DeleteGame(gameId);
            return $"Game {game.Name} berhasil dihapus";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public List<Game> GetPendingRefundGames()
    {
        return DatabaseHelper.GetPendingRefundGames();
    }

    public Game GetPendingRefundGameById(int gameId)
    {
        return DatabaseHelper.GetPendingRefundGameByGameId(gameId);
    }

    public string ProcessRefund(Game game, bool approve)
    {
        if (game == null)
            return "Game tidak ditemukan";

        if (game.Status != GameStatus.PendingRefund)
            return "Game tidak dalam status pending refund";

        GameAction action = approve ? GameAction.ApproveRefund : GameAction.RejectRefund;
        GameStatus nextStatus = gameStateMachine.Move(game.Status, action);
        DatabaseHelper.SetUserGameStatus(game.UserId, game.Id, nextStatus);
        game.Status = nextStatus;

        if (approve)
        {
            DatabaseHelper.AddWalletBalance(game.UserId, game.Price);
            return $"Refund disetujui. Saldo user dikembalikan sebesar Rp{game.Price}";
        }

        return "Refund ditolak";
    }


    public string BanWallet(string username)
    {
        try
        {
            User user = DatabaseHelper.GetUserByUsername(username.Trim());

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak bisa dibanned";

            string message = user.Wallet.ChangeState(WalletAction.Ban);

            if (user.Wallet.CurrentState != WalletState.Banned)
                return message;

            DatabaseHelper.UpdateWallet(user);
            return $"Wallet user {user.Username} berhasil dibanned";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string UnbanWallet(string username)
    {
        try
        {
            User user = DatabaseHelper.GetUserByUsername(username.Trim());

            if (user.Role == UserRole.Admin)
                return "Wallet admin tidak perlu di-unban";

            string message = user.Wallet.ChangeState(WalletAction.Unban);

            if (user.Wallet.CurrentState != WalletState.Active)
                return message;

            DatabaseHelper.UpdateWallet(user);
            return $"Wallet user {user.Username} berhasil di-unban dan aktif kembali";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
