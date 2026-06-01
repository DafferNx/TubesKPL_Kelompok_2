using System;
using System.Collections.Generic;
using TubesKPL_Kelompok_2.Database;

namespace TubesKPL_Kelompok_2.Repositories
{
    public class UserRepository
    {
        public User GetUserById(int id)
            => DatabaseHelper.GetUserById(id);

        public User GetUserByUsername(string username)
            => DatabaseHelper.GetUserByUsername(username);

        public void UpdateWallet(User user)
            => DatabaseHelper.UpdateWallet(user);
    }
}
