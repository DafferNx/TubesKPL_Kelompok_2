using System;

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

        return ChangeGameStatus(game, GameAction.AddToCart, "Game berhasil ditambahkan ke cart");
    }

    public string buyGame(Game game)
    {
        if (game == null) return "Game tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";

        GameAction action = game.Status == GameStatus.Cart
            ? GameAction.Checkout
            : GameAction.BuyDirect;

        return ChangeGameStatus(game, action, "Game berhasil dibeli");
    }

    public string checkoutCart()
    {
        var cartGames = games.Where(game => game.Status == GameStatus.Cart).ToList();
        if (cartGames.Count == 0) return "Tidak ada game di cart untuk checkout";

        foreach (var game in cartGames)
        {
            game.Status = gameStateMachine.Move(game.Status, GameAction.Checkout);
        }

        return "Semua game di cart berhasil dibeli";
    }

    public string refundGame(Game game)
    {
        if (game == null) return "Game tidak ditemukan";
        if (game.Status != GameStatus.Owned) return "Game belum dimiliki";

        return ChangeGameStatus(game, GameAction.Refund, "Game berhasil direfund");
    }

    public List<Game> getCartGames()
    {
        return games.Where(game => game.Status == GameStatus.Cart).ToList();
    }

    public List<Game> getOwnedGames()
    {
        return games.Where(game => game.Status == GameStatus.Owned).ToList();
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
