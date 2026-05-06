using System;
using System.Collections.Generic;
using System.Linq;

public class AdminService
{
    private readonly List<Game> games;
    private readonly GameStateMachine gameStateMachine;

    public AdminService(List<Game> games)
    {
        this.games = games;
        gameStateMachine = new GameStateMachine();
    }

    public string AddGame(string name, int price)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Nama game tidak boleh kosong";

        if (price < 0)
            return "Harga game tidak boleh negatif";

        int newId = games.Count == 0 ? 1 : games.Max(game => game.Id) + 1;
        games.Add(new Game(newId, name.Trim(), price));

        return $"Game berhasil ditambahkan dengan ID {newId}";
    }

    public List<Game> GetPendingRefundGames()
    {
        return games.Where(game => game.Status == GameStatus.PendingRefund).ToList();
    }

    public string ProcessRefund(Game game, bool approve)
    {
        if (game == null)
            return "Game tidak ditemukan";

        if (game.Status != GameStatus.PendingRefund)
            return "Game tidak dalam status pending refund";

        GameAction action = approve ? GameAction.ApproveRefund : GameAction.RejectRefund;
        game.Status = gameStateMachine.Move(game.Status, action);

        return approve ? "Refund disetujui" : "Refund ditolak";
    }
}
