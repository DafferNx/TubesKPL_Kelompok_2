using System;

public class GameService
{
	private List<Game> games;
	public GameService(List<Game> games)
	{
		this.games = games;
	}

	public Game getGameById(int id)
	{
		var game = games.Find(game => game.Id == id);
		if(game == null) throw new Exception("Game tidak ditemukan");
		return game;
	}

	public string addToCart(Game game)
	{
		if (game == null) return "Game tidak ditemukan";
		if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
		if (game.Status == GameStatus.Cart) return "Game sudah ada di cart";

		game.Status = GameStatus.Cart;
		return "Game berhasil ditambahkan ke cart";
    }

	public string buyGame(Game game)
	{
		if (game == null) return "Game tidak ditemukan";
		if (game.Status == GameStatus.Owned) return "Game sudah dimiliki";
		if (game.Status != GameStatus.Cart) return "Game harus ada di cart untuk dibeli";
		game.Status = GameStatus.Owned;
		return "Game berhasil dibeli";
    }

	public string checkoutCart()
	{
		var cartGames = games.Where(game => game.Status == GameStatus.Cart).ToList();
		if (cartGames.Count == 0) return "Tidak ada game di cart untuk checkout";
		foreach (var game in cartGames)
		{
			buyGame(game);
		}
		return "Semua game di cart berhasil dibeli";
    }

	public string refundGame(Game game)
	{
		if (game == null) return "Game tidak ditemukan";
		if (game.Status != GameStatus.Owned) return "Game belum dimiliki";
		game.Status = GameStatus.NotOwned;
		return "Game berhasil direfund";
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
}
