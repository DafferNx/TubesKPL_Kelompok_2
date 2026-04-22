using System;
using System.Collections.Generic;
using System.Text;

public class Game
{
    public int Id {  get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public GameStatus Status { get; set; }

    public Game(int id, string name, int price)
    {
        if (id <= 0)
            throw new Exception("Id Harus lebih dari 0");
        if (string.IsNullOrEmpty(name))
            throw new Exception("Nama game tidak boleh kosong");
        if (price < 0)
            throw new Exception("Harga tidak boleh negatif");

        Id = id;
        Name = name;
        Price = price;
        Status = GameStatus.NotOwned;

        if (Status != GameStatus.NotOwned)
            throw new Exception("Status awal harus NotOwned");
    }

    public Game() { }

}