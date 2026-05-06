using System;
using System.Collections.Generic;
using System.Linq;

public class Wallet
{
    public int Balance { get; private set; }
    public WalletState CurrentState { get; private set; }

    private static readonly Dictionary<(WalletState State, WalletAction Action), WalletState> transitions =
        new Dictionary<(WalletState, WalletAction), WalletState>
    {
        { (WalletState.Inactive, WalletAction.Activate), WalletState.Active },
        { (WalletState.Active, WalletAction.Deactivate), WalletState.Inactive },
        { (WalletState.Active, WalletAction.Ban), WalletState.Banned },
        { (WalletState.Banned, WalletAction.Unban), WalletState.Active }
    };

    public Wallet()
    {
        CurrentState = WalletState.Inactive;
        Balance = 0;
    }

    public string ChangeState(WalletAction action)
    {
        var key = (CurrentState, action);

        if (!transitions.TryGetValue(key, out WalletState nextState))
        {
            return $"Aksi {action} tidak valid untuk wallet {CurrentState}";
        }

        CurrentState = nextState;
        return $"Wallet state berubah menjadi {CurrentState}";
    }

    public string TopUp(int amount)
    {
        if (CurrentState != WalletState.Active)
            return "Wallet harus aktif untuk top up";

        WalletValidator validator = new WalletValidator();
        var result = validator.Validate(amount);

        if (!result.IsValid)
            return string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));

        Balance += amount;
        return $"Top up berhasil. Balance sekarang: Rp{Balance}";
    }

    public bool DeductBalance(int amount, out string message)
    {
        if (CurrentState != WalletState.Active)
        {
            message = "Wallet harus aktif untuk membeli game";
            return false;
        }

        WalletValidator validator = new WalletValidator();
        var result = validator.Validate(amount);

        if (!result.IsValid)
        {
            message = string.Join(Environment.NewLine, result.Errors.Select(error => error.ErrorMessage));
            return false;
        }

        if (Balance < amount)
        {
            message = "Saldo tidak cukup";
            return false;
        }

        Balance -= amount;
        message = $"Pembayaran berhasil. Sisa saldo: Rp{Balance}";
        return true;
    }
}
