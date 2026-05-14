using Microsoft.Data.Sqlite;
using System.IO;

namespace TubesKPL_Kelompok_2.Database;

public static class DatabaseHelper
{
    private static readonly string DatabasePath = ResolveDatabasePath();
    private static readonly string ConnectionString = $"Data Source={DatabasePath}";

    private static string ResolveDatabasePath()
    {
        DirectoryInfo? directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory != null)
        {
            string currentProjectFile = Path.Combine(directory.FullName, "TubesKPL_Kelompok_2.csproj");
            if (File.Exists(currentProjectFile))
            {
                return BuildDatabasePath(directory.FullName);
            }

            string siblingProjectFile = Path.Combine(
                directory.FullName,
                "TubesKPL_Kelompok_2",
                "TubesKPL_Kelompok_2.csproj"
            );

            if (File.Exists(siblingProjectFile))
            {
                string projectDirectory = Path.Combine(directory.FullName, "TubesKPL_Kelompok_2");
                return BuildDatabasePath(projectDirectory);
            }

            directory = directory.Parent;
        }

        string fallbackDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
        Directory.CreateDirectory(fallbackDirectory);
        return Path.Combine(fallbackDirectory, "game_store.db");
    }

    private static string BuildDatabasePath(string projectDirectory)
    {
        string dataDirectory = Path.Combine(projectDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        return Path.Combine(dataDirectory, "game_store.db");
    }

    public static void InitializeDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        ExecuteNonQuery(connection, @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL
            );");

        ExecuteNonQuery(connection, @"
            CREATE TABLE IF NOT EXISTS Wallets (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL UNIQUE,
                Balance INTEGER NOT NULL DEFAULT 0,
                State TEXT NOT NULL DEFAULT 'Inactive',
                FOREIGN KEY(UserId) REFERENCES Users(Id)
            );");

        ExecuteNonQuery(connection, @"
            CREATE TABLE IF NOT EXISTS Games (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Price INTEGER NOT NULL
            );");

        ExecuteNonQuery(connection, @"
            CREATE TABLE IF NOT EXISTS UserGames (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                GameId INTEGER NOT NULL,
                State TEXT NOT NULL,
                FOREIGN KEY(UserId) REFERENCES Users(Id),
                FOREIGN KEY(GameId) REFERENCES Games(Id),
                UNIQUE(UserId, GameId)
            );");

        SeedDefaultData(connection);
    }

    public static void ResetDatabase()
    {
        if (File.Exists(DatabasePath))
        {
            File.Delete(DatabasePath);
        }

        InitializeDatabase();
    }

    public static List<Game> GetAllGames()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        SELECT Id, Name, Price
        FROM Games
        ORDER BY Id;";

        using var reader = command.ExecuteReader();
        var games = new List<Game>();

        while (reader.Read())
        {
            games.Add(new Game
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetInt32(2),
                Status = GameStatus.NotOwned
            });
        }

        return games;
    }


    public static Game GetGameById(int gameId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT Id, Name, Price
            FROM Games
            WHERE Id = $gameId;";
        command.Parameters.AddWithValue("$gameId", gameId);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            throw new Exception("Game tidak ditemukan");

        return new Game
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Price = reader.GetInt32(2),
            Status = GameStatus.NotOwned
        };
    }

    public static void UpdateGame(int gameId, string name, int price)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Games
            SET Name = $name, Price = $price
            WHERE Id = $gameId;";
        command.Parameters.AddWithValue("$gameId", gameId);
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$price", price);

        int affectedRows = command.ExecuteNonQuery();
        if (affectedRows == 0)
            throw new Exception("Game tidak ditemukan");
    }

    public static void DeleteGame(int gameId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        using var deleteUserGamesCommand = connection.CreateCommand();
        deleteUserGamesCommand.Transaction = transaction;
        deleteUserGamesCommand.CommandText = @"
            DELETE FROM UserGames
            WHERE GameId = $gameId;";
        deleteUserGamesCommand.Parameters.AddWithValue("$gameId", gameId);
        deleteUserGamesCommand.ExecuteNonQuery();

        using var deleteGameCommand = connection.CreateCommand();
        deleteGameCommand.Transaction = transaction;
        deleteGameCommand.CommandText = @"
            DELETE FROM Games
            WHERE Id = $gameId;";
        deleteGameCommand.Parameters.AddWithValue("$gameId", gameId);

        int affectedRows = deleteGameCommand.ExecuteNonQuery();
        if (affectedRows == 0)
        {
            transaction.Rollback();
            throw new Exception("Game tidak ditemukan");
        }

        transaction.Commit();
    }

    public static void UpdateUserGameState(int userId, int gameId, string state)
    {
        if (!Enum.TryParse<GameStatus>(state, out var parsedState))
            throw new Exception("Status game tidak valid");

        SetUserGameStatus(userId, gameId, parsedState);
    }

    public static void UpdateWalletState(int userId, string state)
    {
        if (!Enum.TryParse<WalletState>(state, out var parsedState))
            throw new Exception("Status wallet tidak valid");

        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        UPDATE Wallets
        SET State = $state
        WHERE UserId = $userId;";
        command.Parameters.AddWithValue("$state", parsedState.ToString());
        command.Parameters.AddWithValue("$userId", userId);

        int affectedRows = command.ExecuteNonQuery();
        if (affectedRows == 0)
            throw new Exception("Wallet user tidak ditemukan");
    }

    public static void ApproveRefund(int userId, int gameId)
    {
        Game game = GetGameForUser(userId, gameId);

        if (game.Status != GameStatus.PendingRefund)
            throw new Exception("Game tidak dalam status pending refund");

        SetUserGameStatus(userId, gameId, GameStatus.NotOwned);
        AddWalletBalance(userId, game.Price);
    }

    public static void RejectRefund(int userId, int gameId)
    {
        Game game = GetGameForUser(userId, gameId);

        if (game.Status != GameStatus.PendingRefund)
            throw new Exception("Game tidak dalam status pending refund");

        SetUserGameStatus(userId, gameId, GameStatus.Owned);
    }

    public static List<User> GetAllUsers()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
        SELECT u.Id, u.Username, u.Password, u.Role, w.Balance, w.State
        FROM Users u
        INNER JOIN Wallets w ON w.UserId = u.Id
        ORDER BY u.Id;";

        using var reader = command.ExecuteReader();
        var users = new List<User>();

        while (reader.Read())
            users.Add(MapUser(reader));

        return users;
    }

    public static User GetUserByUsername(string username)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT u.Id, u.Username, u.Password, u.Role, w.Balance, w.State
            FROM Users u
            INNER JOIN Wallets w ON w.UserId = u.Id
            WHERE u.Username = $username;";
        command.Parameters.AddWithValue("$username", username);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            throw new Exception("User tidak ditemukan");

        return MapUser(reader);
    }

    public static User Login(string username, string password)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT u.Id, u.Username, u.Password, u.Role, w.Balance, w.State
            FROM Users u
            INNER JOIN Wallets w ON w.UserId = u.Id
            WHERE u.Username = $username AND u.Password = $password;";
        command.Parameters.AddWithValue("$username", username);
        command.Parameters.AddWithValue("$password", password);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            throw new Exception("Username atau password salah");

        return MapUser(reader);
    }

    public static User GetUserById(int userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT u.Id, u.Username, u.Password, u.Role, w.Balance, w.State
            FROM Users u
            INNER JOIN Wallets w ON w.UserId = u.Id
            WHERE u.Id = $userId;";
        command.Parameters.AddWithValue("$userId", userId);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            throw new Exception("User tidak ditemukan");

        return MapUser(reader);
    }

    public static List<Game> GetGamesForUser(int userId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT g.Id, g.Name, g.Price, COALESCE(ug.State, 'NotOwned') AS State
            FROM Games g
            LEFT JOIN UserGames ug ON ug.GameId = g.Id AND ug.UserId = $userId
            ORDER BY g.Id;";
        command.Parameters.AddWithValue("$userId", userId);

        using var reader = command.ExecuteReader();
        var games = new List<Game>();

        while (reader.Read())
            games.Add(MapGame(reader, userId));

        return games;
    }

    public static Game GetGameForUser(int userId, int gameId)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT g.Id, g.Name, g.Price, COALESCE(ug.State, 'NotOwned') AS State
            FROM Games g
            LEFT JOIN UserGames ug ON ug.GameId = g.Id AND ug.UserId = $userId
            WHERE g.Id = $gameId;";
        command.Parameters.AddWithValue("$userId", userId);
        command.Parameters.AddWithValue("$gameId", gameId);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
            throw new Exception("Game tidak ditemukan");

        return MapGame(reader, userId);
    }

    public static List<Game> GetGamesByStatus(int userId, params GameStatus[] statuses)
    {
        var games = GetGamesForUser(userId);
        return games.Where(game => statuses.Contains(game.Status)).ToList();
    }

    public static void SetUserGameStatus(int userId, int gameId, GameStatus status)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO UserGames (UserId, GameId, State)
            VALUES ($userId, $gameId, $state)
            ON CONFLICT(UserId, GameId)
            DO UPDATE SET State = excluded.State;";
        command.Parameters.AddWithValue("$userId", userId);
        command.Parameters.AddWithValue("$gameId", gameId);
        command.Parameters.AddWithValue("$state", status.ToString());
        command.ExecuteNonQuery();
    }

    public static int AddGame(string name, int price)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Games (Name, Price)
            VALUES ($name, $price);
            SELECT last_insert_rowid();";
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$price", price);

        return Convert.ToInt32((long)command.ExecuteScalar()!);
    }

    public static List<Game> GetPendingRefundGames()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT g.Id, g.Name, g.Price, ug.State, ug.UserId
            FROM UserGames ug
            INNER JOIN Games g ON g.Id = ug.GameId
            WHERE ug.State = 'PendingRefund'
            ORDER BY ug.Id;";

        using var reader = command.ExecuteReader();
        var games = new List<Game>();

        while (reader.Read())
        {
            games.Add(new Game
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetInt32(2),
                Status = Enum.Parse<GameStatus>(reader.GetString(3)),
                UserId = reader.GetInt32(4)
            });
        }

        return games;
    }

    public static Game GetPendingRefundGameByGameId(int gameId)
    {
        var game = GetPendingRefundGames().FirstOrDefault(game => game.Id == gameId);
        if (game == null)
            throw new Exception("Game tidak dalam status pending refund");

        return game;
    }

    public static void UpdateWallet(User user)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Wallets
            SET Balance = $balance, State = $state
            WHERE UserId = $userId;";
        command.Parameters.AddWithValue("$balance", user.Wallet.Balance);
        command.Parameters.AddWithValue("$state", user.Wallet.CurrentState.ToString());
        command.Parameters.AddWithValue("$userId", user.Id);
        command.ExecuteNonQuery();
    }

    public static void AddWalletBalance(int userId, int amount)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Wallets
            SET Balance = Balance + $amount
            WHERE UserId = $userId;";
        command.Parameters.AddWithValue("$amount", amount);
        command.Parameters.AddWithValue("$userId", userId);
        command.ExecuteNonQuery();
    }

    public static void SetWalletStateByUsername(string username, WalletState state)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Wallets
            SET State = $state
            WHERE UserId = (SELECT Id FROM Users WHERE Username = $username);";
        command.Parameters.AddWithValue("$state", state.ToString());
        command.Parameters.AddWithValue("$username", username);

        int affectedRows = command.ExecuteNonQuery();
        if (affectedRows == 0)
            throw new Exception("User tidak ditemukan");
    }

    private static void SeedDefaultData(SqliteConnection connection)
    {
        InsertUserIfNotExists(connection, "budi", "123", UserRole.User);
        InsertUserIfNotExists(connection, "admin", "admin", UserRole.Admin);

        using var countCommand = connection.CreateCommand();
        countCommand.CommandText = "SELECT COUNT(*) FROM Games;";
        long gameCount = (long)countCommand.ExecuteScalar()!;

        if (gameCount == 0)
        {
            InsertGame(connection, "Minecraft", 150000);
            InsertGame(connection, "Cyberpunk 2077", 300000);
            InsertGame(connection, "Hollow Knight", 120000);
        }
    }

    private static void InsertUserIfNotExists(SqliteConnection connection, string username, string password, UserRole role)
    {
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT OR IGNORE INTO Users (Username, Password, Role)
            VALUES ($username, $password, $role);";
        command.Parameters.AddWithValue("$username", username);
        command.Parameters.AddWithValue("$password", password);
        command.Parameters.AddWithValue("$role", role.ToString());
        command.ExecuteNonQuery();

        int userId = GetUserId(connection, username);

        using var walletCommand = connection.CreateCommand();
        walletCommand.CommandText = @"
            INSERT OR IGNORE INTO Wallets (UserId, Balance, State)
            VALUES ($userId, 0, 'Inactive');";
        walletCommand.Parameters.AddWithValue("$userId", userId);
        walletCommand.ExecuteNonQuery();
    }

    private static int GetUserId(SqliteConnection connection, string username)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id FROM Users WHERE Username = $username;";
        command.Parameters.AddWithValue("$username", username);
        return Convert.ToInt32((long)command.ExecuteScalar()!);
    }

    private static void InsertGame(SqliteConnection connection, string name, int price)
    {
        using var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Games (Name, Price)
            VALUES ($name, $price);";
        command.Parameters.AddWithValue("$name", name);
        command.Parameters.AddWithValue("$price", price);
        command.ExecuteNonQuery();
    }

    private static User MapUser(SqliteDataReader reader)
    {
        return new User(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetString(2),
            Enum.Parse<UserRole>(reader.GetString(3)),
            new Wallet(reader.GetInt32(4), Enum.Parse<WalletState>(reader.GetString(5)))
        );
    }

    private static Game MapGame(SqliteDataReader reader, int userId)
    {
        return new Game
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Price = reader.GetInt32(2),
            Status = Enum.Parse<GameStatus>(reader.GetString(3)),
            UserId = userId
        };
    }

    private static void ExecuteNonQuery(SqliteConnection connection, string query)
    {
        using var command = new SqliteCommand(query, connection);
        command.ExecuteNonQuery();
    }
}
