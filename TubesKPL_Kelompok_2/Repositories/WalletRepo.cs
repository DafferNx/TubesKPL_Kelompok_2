using System;
using TubesKPL_Kelompok_2.Database;

namespace TubesKPL_Kelompok_2.Repositories
{
    public class WalletRepository
    {
        public void UpdateWallet(User user)
            => DatabaseHelper.UpdateWallet(user);

        public void AddWalletBalance(int userId, int amount)
            => DatabaseHelper.AddWalletBalance(userId, amount);

        public void UpdateWalletState(int userId, string state)
            => DatabaseHelper.UpdateWalletState(userId, state);
    }
}
