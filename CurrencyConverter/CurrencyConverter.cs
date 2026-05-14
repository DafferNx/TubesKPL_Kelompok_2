namespace Libraries
{
    public class CurrencyConverter
    {
        private static readonly Dictionary<string, decimal> RatesFromIdr = new()
        {
            { "IDR", 1m },
            { "USD", 0.000061m },
        };

        private static readonly Dictionary<string, string> Symbols = new()
        {
            { "IDR", "Rp" },
            { "USD", "$" },
        };

        public static decimal ConvertFromIdr(decimal amountInIdr, string currencyCode)
        {
            currencyCode = currencyCode.ToUpper();

            if (!RatesFromIdr.ContainsKey(currencyCode))
                return amountInIdr;

            return amountInIdr * RatesFromIdr[currencyCode];
        }

        public static string Format(decimal amountInIdr, string currencyCode)
        {
            currencyCode = currencyCode.ToUpper();

            decimal converted = ConvertFromIdr(amountInIdr, currencyCode);
            string symbol = Symbols.ContainsKey(currencyCode) ? Symbols[currencyCode] : "";

            return currencyCode switch
            {
                "IDR" => $"{symbol}{converted:N0}",
                "JPY" => $"{symbol}{converted:N0}",
                _ => $"{symbol}{converted:N2}"
            };
        }

        public static bool IsSupported(string currencyCode)
        {
            return RatesFromIdr.ContainsKey(currencyCode.ToUpper());
        }

    }
}
