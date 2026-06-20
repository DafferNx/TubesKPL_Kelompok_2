using System;
using System.Collections.Generic;

/// <summary>
/// Singleton pattern — hanya ada satu sumber kebenaran untuk currency aktif
/// di seluruh aplikasi (console, GUI, maupun API). Mencegah konflik state
/// jika beberapa bagian kode mencoba membaca/menulis currency secara bersamaan.
/// </summary>
public sealed class RuntimeConfig
{
    private static readonly Lazy<RuntimeConfig> _instance =
        new Lazy<RuntimeConfig>(() => new RuntimeConfig());

    public static RuntimeConfig Instance => _instance.Value;

    public string Currency { get; private set; } = "IDR";

    private string? _loadedFilePath;

    // Constructor private — tidak bisa di-instansiasi dari luar (Singleton)
    private RuntimeConfig() { }

    public class CurrencyConfigData
    {
        public string Currency { get; set; } = "IDR";
    }

    public void Load(string filePath)
    {
        _loadedFilePath = filePath;

        try
        {
            var repo = new Repository<CurrencyConfigData>();
            var configList = repo.Load(filePath);

            if (configList == null || configList.Count == 0)
            {
                Console.WriteLine("[Config] File config kosong, menggunakan default: IDR");
                return;
            }

            string code = configList[0].Currency.Trim().ToUpper();

            if (!Libraries.CurrencyConverter.IsSupported(code))
            {
                Console.WriteLine($"[Config] Currency '{code}' tidak didukung, menggunakan default: IDR");
                return;
            }

            Currency = code;
            Console.WriteLine($"[Config] Currency dimuat: {Currency}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Config] Gagal load config: {ex.Message}. Menggunakan default: IDR");
        }
    }

    public string SetCurrency(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            return "Currency tidak boleh kosong";

        string code = currencyCode.Trim().ToUpper();

        if (!Libraries.CurrencyConverter.IsSupported(code))
            return $"Currency '{code}' tidak didukung. Currency yang tersedia: IDR, USD";

        Currency = code;
        return $"Currency berhasil diganti ke {Currency}";
    }

    /// <summary>
    /// Menyimpan currency aktif ke file JSON menggunakan Repository&lt;T&gt; generic
    /// yang sama dipakai saat Load — konsisten dengan teknik Parameterization/Generics.
    /// </summary>
    public void Save(string? filePath = null)
    {
        string targetPath = filePath ?? _loadedFilePath
            ?? throw new InvalidOperationException("Path config belum diketahui. Panggil Load() terlebih dahulu atau berikan filePath.");

        try
        {
            var repo = new Repository<CurrencyConfigData>();
            var data = new List<CurrencyConfigData> { new CurrencyConfigData { Currency = Currency } };
            repo.Save(targetPath, data);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Config] Gagal menyimpan config: {ex.Message}");
        }
    }
}
