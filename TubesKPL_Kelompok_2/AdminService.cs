using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

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
        int newId = games.Count == 0 ? 1 : games.Max(game => game.Id) + 1;
        Game newGame = new Game
        {
            Id = newId,
            Name = name.Trim(),
            Price = price,
            Status = GameStatus.NotOwned
        };

        GameValidator validator = new GameValidator();
        ValidationResult result = validator.Validate(newGame);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        games.Add(newGame);

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
