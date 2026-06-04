using System;
using System.Collections.Generic;
using System.Text;
using TubesKPL_Kelompok_2.Database;

namespace TubesKPL_Kelompok_2.Repositories
{
    public class AuthRepository
    {
        public User Login(
            string username,
            string password)
        {
            return DatabaseHelper.Login(
                username,
                password);
        }
    }
}
