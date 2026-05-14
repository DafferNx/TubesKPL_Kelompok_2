using System;
using System.Collections.Generic;
using System.Linq;
using TubesKPL_Kelompok_2.Database;
public class GameService
{
    private readonly GameStateMachine gameStateMachine;

    public GameService()
    {
        gameStateMachine = new GameStateMachine();
    }

    public List<Game> getAllGames(int userId)
    {
        return DatabaseHelper.GetGamesForUser(userId);
    }

    public Game getGameById(int userId, int id)
    {
        return DatabaseHelper.GetGameForUser(userId, id);
    }

    public string addToCart(int userId, Game game)
    {
        if (game == null) return "Game tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
        if (game.Status == GameStatus.Cart) return "Game sudah ada di cart";
        if (game.Status == GameStatus.PendingRefund) return "Game sedang menunggu proses refund";

        return ChangeGameStatus(userId, game, GameAction.AddToCart, "Game berhasil ditambahkan ke cart");
    }

    public string removeFromCart(int userId, Game game)
    {
        if (game == null) return "Game tidak ditemukan";
        if (game.Status != GameStatus.Cart) return "Game tidak ada di cart";

        DatabaseHelper.SetUserGameStatus(userId, game.Id, GameStatus.NotOwned);
        return "Game berhasil dihapus dari cart";
    }

    public string buyGame(User user, Game game)
    {
        if (user == null) return "User tidak ditemukan";
        if (game == null) return "Game tidak ditemukan";
        if (user.Wallet == null) return "Wallet tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
        if (game.Status == GameStatus.PendingRefund) return "Game sedang menunggu proses refund";

        if (!user.Wallet.DeductBalance(game.Price, out string walletMessage))
            return walletMessage;

        GameAction action = game.Status == GameStatus.Cart
            ? GameAction.Checkout
            : GameAction.BuyDirect;

        string stateMessage = ChangeGameStatus(user.Id, game, action, "Game berhasil dibeli");
        DatabaseHelper.UpdateWallet(user);

        return $"{stateMessage}. {walletMessage}";
    }

    public string checkoutCart(User user)
    {
        if (user == null) return "User tidak ditemukan";
        if (user.Wallet == null) return "Wallet tidak ditemukan";

        var cartGames = getCartGames(user.Id);
        if (cartGames.Count == 0) return "Tidak ada game di cart untuk checkout";

        int totalPrice = cartGames.Sum(game => game.Price);
        if (!user.Wallet.DeductBalance(totalPrice, out string walletMessage))
            return walletMessage;

        foreach (var game in cartGames)
        {
            GameStatus nextStatus = gameStateMachine.Move(game.Status, GameAction.Checkout);
            DatabaseHelper.SetUserGameStatus(user.Id, game.Id, nextStatus);
        }

        DatabaseHelper.UpdateWallet(user);
        return $"Semua game di cart berhasil dibeli. {walletMessage}";
    }

    public string requestRefund(int userId, Game game)
    {
        RefundValidator validator = new RefundValidator();
        var result = validator.Validate(game);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        return ChangeGameStatus(userId, game, GameAction.RequestRefund, "Request refund berhasil diajukan dan menunggu persetujuan admin");
    }

    public List<Game> getCartGames(int userId)
    {
        return DatabaseHelper.GetGamesByStatus(userId, GameStatus.Cart);
    }

    public List<Game> getOwnedGames(int userId)
    {
        return DatabaseHelper.GetGamesByStatus(userId, GameStatus.Owned, GameStatus.PendingRefund);
    }

    public int getTotalCartPrice(int userId)
    {
        return getCartGames(userId).Sum(game => game.Price);
    }

    private string ChangeGameStatus(int userId, Game game, GameAction action, string successMessage)
    {
        try
        {
            GameStatus nextStatus = gameStateMachine.Move(game.Status, action);
            DatabaseHelper.SetUserGameStatus(userId, game.Id, nextStatus);
            game.Status = nextStatus;
            return successMessage;
        }
        catch (InvalidOperationException ex)
        {
            return ex.Message;
        }
    }
}
