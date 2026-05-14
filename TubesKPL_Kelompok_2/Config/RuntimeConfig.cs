public static class RuntimeConfig
{
    public static string Currency { get; private set; } = "IDR";

    public static string SetCurrency(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            return "Currency tidak boleh kosong";

        Currency = currencyCode.Trim().ToUpper();
        return $"Currency berhasil diganti ke {Currency}";
    }
}
