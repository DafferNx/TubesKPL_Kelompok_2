using System;
using System.Collections.Generic;
using TubesKPL_Kelompok_2.Database;

namespace TubesKPL_Kelompok_2.Repositories
{
    public class GameRepository
    {
        public List<Game> GetGamesForUser(int userId)
            => DatabaseHelper.GetGamesForUser(userId);

        public Game GetGameForUser(int userId, int gameId)
            => DatabaseHelper.GetGameForUser(userId, gameId);

        public List<Game> GetGamesByStatus(int userId, params GameStatus[] statuses)
            => DatabaseHelper.GetGamesByStatus(userId, statuses);

        public void SetUserGameStatus(int userId, int gameId, GameStatus status)
            => DatabaseHelper.SetUserGameStatus(userId, gameId, status);

        public List<Game> GetAllGames()
            => DatabaseHelper.GetAllGames();

        public Game GetGameById(int id)
            => DatabaseHelper.GetGameById(id);
    }
}
