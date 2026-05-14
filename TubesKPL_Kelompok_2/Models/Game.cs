public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }

    // Status ini adalah status game untuk user tertentu.
    // Data master game tetap disimpan di tabel Games.
    // Status per user disimpan di tabel UserGames.
    public GameStatus Status { get; set; } = GameStatus.NotOwned;

    // Dipakai saat admin memproses refund dari tabel UserGames.
    public int UserId { get; set; }

    public Game() { }

    public Game(int id, string name, int price)
    {
        if (id <= 0)
            throw new Exception("Id harus lebih dari 0");
        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Nama game tidak boleh kosong");
        if (price < 0)
            throw new Exception("Harga tidak boleh negatif");

        Id = id;
        Name = name;
        Price = price;
        Status = GameStatus.NotOwned;
    }
}
