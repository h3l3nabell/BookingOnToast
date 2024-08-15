namespace BookingOnToast.Domain.Listings;

public record Currency
{
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Gbp = new("GBP");
    public static readonly Currency Eur = new("EUR");
    internal static readonly Currency None = new("");
    private Currency(string code) => Code = code;
    
    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return SupportedCurrencies.FirstOrDefault(c => c.Code == code) ??
               throw new ApplicationException($"The currency {code} is not supported.");
    }

    public static readonly IReadOnlyCollection<Currency> SupportedCurrencies = new[] { Usd, Gbp, Eur };
}


