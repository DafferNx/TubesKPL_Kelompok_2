using System;
using System.Collections.Generic;
using TubesKPL_Kelompok_2.Database;

namespace TubesKPL_Kelompok_2.Repositories
{
    public class AdminRepository
    {
        public List<User> GetAllUsers()
            => DatabaseHelper.GetAllUsers();

        public User GetUserByUsername(string username)
            => DatabaseHelper.GetUserByUsername(username);

        public List<Game> GetPendingRefundGames()
            => DatabaseHelper.GetPendingRefundGames();

        public Game GetPendingRefundGameByGameId(int gameId)
            => DatabaseHelper.GetPendingRefundGameByGameId(gameId);

        public void ApproveRefund(int userId, int gameId)
            => DatabaseHelper.ApproveRefund(userId, gameId);

        public void RejectRefund(int userId, int gameId)
            => DatabaseHelper.RejectRefund(userId, gameId);

        public int AddGame(string name, int price)
            => DatabaseHelper.AddGame(name, price);

        public void UpdateGame(int gameId, string name, int price)
            => DatabaseHelper.UpdateGame(gameId, name, price);

        public void DeleteGame(int gameId)
            => DatabaseHelper.DeleteGame(gameId);

        public List<Game> GetAllGames()
            => DatabaseHelper.GetAllGames();

        public Game GetGameById(int gameId)
            => DatabaseHelper.GetGameById(gameId);
    }
}
