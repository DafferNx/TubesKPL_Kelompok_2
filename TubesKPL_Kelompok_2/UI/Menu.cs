using System;
using System.Collections.Generic;
using Libraries;

public static class Menu
{
    // Helper: format angka sesuai currency aktif dari RuntimeConfig
    private static string FormatMoney(int amount)
    {
        return CurrencyConverter.Format(amount, RuntimeConfig.Instance.Currency);
    }

    public static void ShowRoleMenu()
    {
        Console.WriteLine("=== LOGIN SETIM ===");
        Console.WriteLine("Default user : budi / 123");
        Console.WriteLine("Default admin: admin / admin");
        Console.WriteLine();
    }

    public static void ShowStore(List<Game> games, User user)
    {
        Console.WriteLine("=== STORE ===");
        Console.WriteLine($"User: {user.Username} | Wallet: {user.Wallet.CurrentState} | Balance: {FormatMoney(user.Wallet.Balance)}");
        Console.WriteLine($"Currency aktif: {RuntimeConfig.Instance.Currency}");
        Console.WriteLine();

        foreach (var game in games)
        {
            Console.WriteLine($"{game.Id}. {game.Name} - {FormatMoney(game.Price)} [{game.Status}]");
        }

        Console.WriteLine();
        Console.WriteLine("11. Library");
        Console.WriteLine("12. Cart");

        // Tampilkan opsi wallet sesuai state saat ini — Table-driven construction
        string walletToggleLabel = user.Wallet.CurrentState == WalletState.Active
            ? "13. Nonaktifkan Wallet"
            : "13. Aktifkan Wallet";
        Console.WriteLine(walletToggleLabel);

        Console.WriteLine("14. Top Up Wallet");
        Console.WriteLine("0. Logout");
        Console.WriteLine("Pilih nomor untuk lihat detail game / berpindah halaman");
    }

    public static void ShowGameDetail(Game game)
    {
        Console.WriteLine("=== DETAIL GAME ===");
        Console.WriteLine($"ID     : {game.Id}");
        Console.WriteLine($"Nama   : {game.Name}");
        Console.WriteLine($"Harga  : {FormatMoney(game.Price)}");
        Console.WriteLine($"Status : {game.Status}");

        Console.WriteLine();
        Console.WriteLine("1. Buy langsung");
        Console.WriteLine("2. Add to Cart");
        Console.WriteLine("3. Kembali ke Store");
    }

    public static void ShowCart(List<Game> cartGames, int totalPrice)
    {
        Console.WriteLine("=== CART ===");

        if (cartGames.Count == 0)
        {
            Console.WriteLine("Cart kosong.");
        }
        else
        {
            foreach (var game in cartGames)
            {
                Console.WriteLine($"{game.Id}. {game.Name} - {FormatMoney(game.Price)}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total harga: {FormatMoney(totalPrice)}");
        }

        Console.WriteLine();
        Console.WriteLine("1. Checkout / Beli semua");
        Console.WriteLine("2. Hapus game dari cart");
        Console.WriteLine("3. Kembali ke Store");
    }

    public static void ShowLibrary(List<Game> ownedGames)
    {
        Console.WriteLine("=== LIBRARY ===");

        if (ownedGames.Count == 0)
        {
            Console.WriteLine("Library kosong.");
        }
        else
        {
            foreach (var game in ownedGames)
            {
                Console.WriteLine($"{game.Id}. {game.Name} - {FormatMoney(game.Price)} [{game.Status}]");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Pilih ID game untuk detail");
        Console.WriteLine("0. Kembali ke Store");
    }

    public static void ShowLibraryDetail(Game game)
    {
        Console.WriteLine("=== DETAIL LIBRARY ===");
        Console.WriteLine($"ID     : {game.Id}");
        Console.WriteLine($"Nama   : {game.Name}");
        Console.WriteLine($"Harga  : {FormatMoney(game.Price)}");
        Console.WriteLine($"Status : {game.Status}");

        Console.WriteLine();
        Console.WriteLine("1. Kembali ke Library");
        Console.WriteLine("2. Ajukan Refund");
    }

    public static void ShowAdminMenu()
    {
        Console.WriteLine("=== ADMIN MENU ===");
        Console.WriteLine("1. Tambah Game ke Database");
        Console.WriteLine("2. Edit Game");
        Console.WriteLine("3. Hapus Game");
        Console.WriteLine("4. Lihat Request Refund");
        Console.WriteLine("5. Ban Wallet User");
        Console.WriteLine("6. Unban Wallet User");
        Console.WriteLine("0. Logout");
    }

    public static void ShowAdminGameList(List<Game> games)
    {
        Console.WriteLine("=== DAFTAR GAME ===");

        if (games.Count == 0)
        {
            Console.WriteLine("Belum ada game di database.");
        }
        else
        {
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Id}. {game.Name} - {FormatMoney(game.Price)}");
            }
        }

        Console.WriteLine();
    }

    public static void ShowPendingRefunds(List<Game> pendingRefundGames)
    {
        Console.WriteLine("=== REQUEST REFUND ===");

        if (pendingRefundGames.Count == 0)
        {
            Console.WriteLine("Tidak ada request refund.");
        }
        else
        {
            foreach (var game in pendingRefundGames)
            {
                Console.WriteLine($"{game.Id}. {game.Name} - {FormatMoney(game.Price)} [{game.Status}]");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Pilih ID game untuk proses refund");
        Console.WriteLine("0. Kembali ke Admin Menu");
    }

    public static void ShowRefundDecision(Game game)
    {
        Console.WriteLine("=== PROSES REFUND ===");
        Console.WriteLine($"ID     : {game.Id}");
        Console.WriteLine($"Nama   : {game.Name}");
        Console.WriteLine($"Harga  : {FormatMoney(game.Price)}");
        Console.WriteLine($"Status : {game.Status}");
        Console.WriteLine();
        Console.WriteLine("1. Approve Refund");
        Console.WriteLine("2. Reject Refund");
        Console.WriteLine("0. Kembali");
    }

    public static int GetInput()
    {
        Console.Write("Input: ");

        if (int.TryParse(Console.ReadLine(), out int input))
        {
            return input;
        }

        return -1;
    }

    public static string GetTextInput(string label)
    {
        Console.Write(label);
        return Console.ReadLine() ?? string.Empty;
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("Tekan ENTER untuk lanjut...");
        Console.ReadLine();
    }
}
