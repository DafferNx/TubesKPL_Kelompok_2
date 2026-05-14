using System;
using System.Collections.Generic;
using System.Linq;

public class GameService
{
    private readonly List<Game> games;
    private readonly GameStateMachine gameStateMachine;

    public GameService(List<Game> games)
    {
        this.games = games;
        gameStateMachine = new GameStateMachine();
    }

    public Game getGameById(int id)
    {
        var game = games.Find(game => game.Id == id);
        if (game == null) throw new Exception("Game tidak ditemukan");
        return game;
    }

    public string addToCart(Game game)
    {
        if (game == null) return "Game tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
        if (game.Status == GameStatus.Cart) return "Game sudah ada di cart";
        if (game.Status == GameStatus.PendingRefund) return "Game sedang menunggu proses refund";

        return ChangeGameStatus(game, GameAction.AddToCart, "Game berhasil ditambahkan ke cart");
    }

    public string buyGame(Game game, Wallet wallet)
    {
        if (game == null) return "Game tidak ditemukan";
        if (wallet == null) return "Wallet tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
        if (game.Status == GameStatus.PendingRefund) return "Game sedang menunggu proses refund";

        if (!wallet.DeductBalance(game.Price, out string walletMessage))
            return walletMessage;

        GameAction action = game.Status == GameStatus.Cart
            ? GameAction.Checkout
            : GameAction.BuyDirect;

        string stateMessage = ChangeGameStatus(game, action, "Game berhasil dibeli");
        return $"{stateMessage}. {walletMessage}";
    }

    public string checkoutCart(Wallet wallet)
    {
        if (wallet == null) return "Wallet tidak ditemukan";

        var cartGames = games.Where(game => game.Status == GameStatus.Cart).ToList();
        if (cartGames.Count == 0) return "Tidak ada game di cart untuk checkout";

        int totalPrice = cartGames.Sum(game => game.Price);
        if (!wallet.DeductBalance(totalPrice, out string walletMessage))
            return walletMessage;

        foreach (var game in cartGames)
        {
            game.Status = gameStateMachine.Move(game.Status, GameAction.Checkout);
        }

        return $"Semua game di cart berhasil dibeli. {walletMessage}";
    }

    public string requestRefund(Game game)
    {
        RefundValidator validator = new RefundValidator();
        var result = validator.Validate(game);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        return ChangeGameStatus(game, GameAction.RequestRefund, "Request refund berhasil diajukan dan menunggu persetujuan admin");
    }

    public List<Game> getCartGames()
    {
        return games.Where(game => game.Status == GameStatus.Cart).ToList();
    }

    public List<Game> getOwnedGames()
    {
        return games.Where(game => game.Status == GameStatus.Owned || game.Status == GameStatus.PendingRefund).ToList();
    }

    public int getTotalCartPrice()
    {
        return games.Where(game => game.Status == GameStatus.Cart).Sum(game => game.Price);
    }

    private string ChangeGameStatus(Game game, GameAction action, string successMessage)
    {
        try
        {
            game.Status = gameStateMachine.Move(game.Status, action);
            return successMessage;
        }
        catch (InvalidOperationException ex)
        {
            return ex.Message;
        }
    }
}
