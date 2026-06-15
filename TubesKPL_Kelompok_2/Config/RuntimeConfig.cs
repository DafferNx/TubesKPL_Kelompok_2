using System;

public static class RuntimeConfig
{
    public static string Currency { get; private set; } = "IDR";

    public class CurrencyConfigData
    {
        public string Currency { get; set; } = "IDR";
    }

    public static void Load(string filePath)
    {
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

    public static string SetCurrency(string currencyCode)
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
    /// Menyimpan currency yang aktif ke file JSON agar persist setelah restart.
    /// </summary>
    public static void Save(string filePath)
    {
        try
        {
            string json = $"[\r\n  {{\r\n    \"Currency\": \"{Currency}\"\r\n  }}\r\n]\r\n";
            System.IO.File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Config] Gagal menyimpan config: {ex.Message}");
        }
    }
}
