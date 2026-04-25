using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== STEAM ===");

        var repo = new Repository<Game>();
        var games = repo.Load("games.json");

        Console.WriteLine($"Jumlah game berhasil dimuat: {games.Count}");

        State startState = State.STORE;

        if (File.Exists("workflow.json"))
        {
            string json = File.ReadAllText("workflow.json");
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            if (config != null && config.ContainsKey("initialState"))
            {
                startState = Enum.Parse<State>(config["initialState"]);
            }
        }

        var table = new Dictionary<(State, Input), State>
        {
            {(State.STORE, Input.VIEW_DETAIL), State.DETAIL},

            {(State.DETAIL, Input.ADD_TO_CART), State.CART},
            {(State.DETAIL, Input.BUY_DIRECT), State.LIBRARY},
            {(State.DETAIL, Input.BACK), State.STORE},

            {(State.CART, Input.BUY_CART), State.LIBRARY},
            {(State.CART, Input.BACK), State.STORE},

            {(State.LIBRARY, Input.REFUND), State.LIBRARY},
            {(State.LIBRARY, Input.BACK), State.STORE}
        };

        var fsm = new StateMachine(startState, table);

        Game selectedGame = null;

        while (true)
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine($"Current State: {fsm.CurrentState}");
            Console.WriteLine("=================================");

            switch (fsm.CurrentState)
            {
                case State.STORE:
                    Console.WriteLine("STORE MENU");

                    foreach (var game in games)
                    {
                        Console.WriteLine($"{game.Id}. {game.Name} - {game.Price}");
                    }

                    Console.WriteLine("0. Exit");
                    break;

                case State.DETAIL:
                    Console.WriteLine("DETAIL GAME");

                    if (selectedGame != null)
                    {
                        Console.WriteLine($"Nama  : {selectedGame.Name}");
                        Console.WriteLine($"Harga : {selectedGame.Price}");
                        Console.WriteLine($"Status: {selectedGame.Status}");
                    }

                    Console.WriteLine("\n1. Add to Cart");
                    Console.WriteLine("2. Buy Direct");
                    Console.WriteLine("3. Back to Store");
                    break;

                case State.CART:
                    Console.WriteLine("CART MENU");
                    Console.WriteLine("1. Buy All Cart");
                    Console.WriteLine("2. Back to Store");
                    break;

                case State.LIBRARY:
                    Console.WriteLine("LIBRARY MENU");
                    Console.WriteLine("1. Refund Game");
                    Console.WriteLine("2. Back to Store");
                    break;
            }

            Console.Write("\nInput: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
                continue;

            if (choice == 0)
                break;

            Input input;

            switch (fsm.CurrentState)
            {
                case State.STORE:
                    var game = games.Find(g => g.Id == choice);

                    if (game != null)
                    {
                        selectedGame = game;
                        input = Input.VIEW_DETAIL;
                    }
                    else
                    {
                        Console.WriteLine("Game tidak valid");
                        input = Input.BACK;
                    }
                    break;

                case State.DETAIL:
                    input = choice switch
                    {
                        1 => Input.ADD_TO_CART,
                        2 => Input.BUY_DIRECT,
                        3 => Input.BACK,
                        _ => Input.BACK
                    };
                    break;

                case State.CART:
                    input = choice switch
                    {
                        1 => Input.BUY_CART,
                        2 => Input.BACK,
                        _ => Input.BACK
                    };
                    break;

                case State.LIBRARY:
                    input = choice switch
                    {
                        1 => Input.REFUND,
                        2 => Input.BACK,
                        _ => Input.BACK
                    };
                    break;

                default:
                    input = Input.BACK;
                    break;
            }

            fsm.Send(input);
        }

        Console.WriteLine("\nProgram selesai.");
    }
}
