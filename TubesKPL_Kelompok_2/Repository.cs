using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Repository<T>
{
    public List<T> Load(string file)
    {
        if (!File.Exists(file))
            throw new Exception("File tidak ditemukan");

        string json = File.ReadAllText(file);

        var data = JsonSerializer.Deserialize<List<T>>(json);

        if (data == null)
            throw new Exception("Gagal membaca data");

        return data;
    }
}