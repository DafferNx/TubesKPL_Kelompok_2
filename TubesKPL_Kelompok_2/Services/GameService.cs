using System;
using System.Collections.Generic;
using System.Linq;
using TubesKPL_Kelompok_2.Repositories;

public class GameService
{
    private readonly GameStateMachine gameStateMachine;
    private readonly GameRepository gameRepository;
    private readonly UserRepository userRepository;
    private readonly WalletRepository walletRepository;

    public GameService()
    {
        gameStateMachine = new GameStateMachine();
        gameRepository = new GameRepository();
        userRepository = new UserRepository();
        walletRepository = new WalletRepository();
    }

    public List<Game> GetAllGames(int userId)
    {
        return gameRepository.GetGamesForUser(userId);
    }

    public Game GetGameById(int userId, int gameId)
    {
        return gameRepository.GetGameForUser(userId, gameId);
    }

    public string AddToCart(int userId, int gameId)
    {
        var game = gameRepository.GetGameForUser(userId, gameId);
        if (game == null) return "Game tidak ditemukan";
        if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
        if (game.Status == GameStatus.Cart) return "Game sudah ada di cart";
        if (game.Status == GameStatus.PendingRefund) return "Game sedang menunggu proses refund";

        return ChangeGameStatus(userId, game, GameAction.AddToCart, "Game berhasil ditambahkan ke cart");
    }

    public string RemoveFromCart(int userId, int gameId)
    {
        var game = gameRepository.GetGameForUser(userId, gameId);
        if (game == null) return "Game tidak ditemukan";
        if (game.Status != GameStatus.Cart) return "Game tidak ada di cart";

        gameRepository.SetUserGameStatus(userId, game.Id, GameStatus.NotOwned);
        return "Game berhasil dihapus dari cart";
    }

    public string BuyGame(int userId, int gameId)
    {
        var user = userRepository.GetUserById(userId);
        if (user == null) return "User tidak ditemukan";

        var game = gameRepository.GetGameForUser(userId, gameId);
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
        walletRepository.UpdateWallet(user);

        return $"{stateMessage}. {walletMessage}";
    }

    public string CheckoutCart(int userId)
    {
        var user = userRepository.GetUserById(userId);
        if (user == null) return "User tidak ditemukan";
        if (user.Wallet == null) return "Wallet tidak ditemukan";

        var cartGames = gameRepository.GetGamesByStatus(userId, GameStatus.Cart);
        if (cartGames.Count == 0) return "Tidak ada game di cart untuk checkout";

        int totalPrice = cartGames.Sum(game => game.Price);
        if (!user.Wallet.DeductBalance(totalPrice, out string walletMessage))
            return walletMessage;

        foreach (var game in cartGames)
        {
            GameStatus nextStatus = gameStateMachine.Move(game.Status, GameAction.Checkout);
            gameRepository.SetUserGameStatus(user.Id, game.Id, nextStatus);
        }

        walletRepository.UpdateWallet(user);
        return $"Semua game di cart berhasil dibeli. {walletMessage}";
    }

    public string RequestRefund(int userId, int gameId)
    {
        var game = gameRepository.GetGameForUser(userId, gameId);
        if (game == null) return "Game tidak ditemukan";

        RefundValidator validator = new RefundValidator();
        var result = validator.Validate(game);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        return ChangeGameStatus(userId, game, GameAction.RequestRefund, "Request refund berhasil diajukan dan menunggu persetujuan admin");
    }

    public List<Game> GetCartGames(int userId)
    {
        return gameRepository.GetGamesByStatus(userId, GameStatus.Cart);
    }

    public List<Game> GetOwnedGames(int userId)
    {
        return gameRepository.GetGamesByStatus(userId, GameStatus.Owned, GameStatus.PendingRefund);
    }

    public int GetTotalCartPrice(int userId)
    {
        return GetCartGames(userId).Sum(game => game.Price);
    }

    private string ChangeGameStatus(int userId, Game game, GameAction action, string successMessage)
    {
        try
        {
            GameStatus nextStatus = gameStateMachine.Move(game.Status, action);
            gameRepository.SetUserGameStatus(userId, game.Id, nextStatus);
            game.Status = nextStatus;
            return successMessage;
        }
        catch (InvalidOperationException ex)
        {
            return ex.Message;
        }
    }
}
