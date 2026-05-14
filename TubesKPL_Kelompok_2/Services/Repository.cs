using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Repository<T>
{
    public List<T> Load(string file)
    {
        string filePath = ResolveFilePath(file);

        if (!File.Exists(filePath))
            throw new Exception($"File tidak ditemukan: {filePath}");

        string json = File.ReadAllText(filePath);

        var data = JsonSerializer.Deserialize<List<T>>(json);

        if (data == null)
            throw new Exception("Gagal membaca data");

        return data;
    }

    public void Save(string file, List<T> data)
    {
        string filePath = ResolveFilePath(file);
        string? directory = Path.GetDirectoryName(filePath);

        if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    private string ResolveFilePath(string file)
    {
        if (Path.IsPathRooted(file))
            return file;

        string? directory = AppContext.BaseDirectory;

        while (!string.IsNullOrWhiteSpace(directory))
        {
            bool containsProjectFile = Directory.GetFiles(directory, "*.csproj").Length > 0;
            string candidate = Path.Combine(directory, file);

            if (containsProjectFile || File.Exists(candidate))
                return candidate;

            directory = Directory.GetParent(directory)?.FullName;
        }

        return Path.Combine(Directory.GetCurrentDirectory(), file);
    }
}
