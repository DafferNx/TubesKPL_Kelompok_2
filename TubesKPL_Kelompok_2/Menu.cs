using System;
using System.Collections.Generic;

public static class Menu
{
    public static void ShowStore(List<Game> games)
    {
        Console.WriteLine("=== STORE ===");

        foreach (var game in games)
        {
            Console.WriteLine($"{game.Id}. {game.Name} - Rp{game.Price} [{game.Status}]");
        }
        
        Console.WriteLine();
        Console.WriteLine("11. Library");
        Console.WriteLine("12. Cart");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Pilih nomor untuk lihat detail game / berpindah halaman");
    }

    public static void ShowGameDetail(Game game)
    {
        Console.WriteLine("=== DETAIL GAME ===");
        Console.WriteLine($"ID     : {game.Id}");
        Console.WriteLine($"Nama   : {game.Name}");
        Console.WriteLine($"Harga  : Rp{game.Price}");
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
                Console.WriteLine($"{game.Id}. {game.Name} - Rp{game.Price}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total harga: Rp{totalPrice}");
        }

        Console.WriteLine();
        Console.WriteLine("1. Checkout / Beli semua");
        Console.WriteLine("2. Kembali ke Store");
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
                Console.WriteLine($"{game.Id}. {game.Name} - Rp{game.Price}");
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
        Console.WriteLine($"Harga  : Rp{game.Price}");
        Console.WriteLine($"Status : {game.Status}");

        Console.WriteLine();
        Console.WriteLine("1. Kembali ke Library");
        Console.WriteLine("2. Refund");
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

    public static void ShowMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("Tekan ENTER untuk lanjut...");
        Console.ReadLine();
    }
}