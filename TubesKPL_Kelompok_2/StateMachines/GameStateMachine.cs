using System;
using System.Collections.Generic;

public enum GameAction
{
    AddToCart,
    BuyDirect,
    Checkout,
    RequestRefund,
    ApproveRefund,
    RejectRefund
}

public class GameStateMachine
{
    private readonly Dictionary<(GameStatus Status, GameAction Action), GameStatus> transitions;

    public GameStateMachine()
    {
        transitions = new Dictionary<(GameStatus, GameAction), GameStatus>
        {
            { (GameStatus.NotOwned, GameAction.AddToCart), GameStatus.Cart },
            { (GameStatus.NotOwned, GameAction.BuyDirect), GameStatus.Owned },
            { (GameStatus.Cart, GameAction.Checkout), GameStatus.Owned },
            { (GameStatus.Owned, GameAction.RequestRefund), GameStatus.PendingRefund },
            { (GameStatus.PendingRefund, GameAction.ApproveRefund), GameStatus.NotOwned },
            { (GameStatus.PendingRefund, GameAction.RejectRefund), GameStatus.Owned }
        };
    }

    public GameStatus Move(GameStatus currentStatus, GameAction action)
    {
        var key = (currentStatus, action);

        if (!transitions.TryGetValue(key, out GameStatus nextStatus))
            throw new InvalidOperationException($"Aksi {action} tidak valid untuk status game {currentStatus}");

        return nextStatus;
    }
}
