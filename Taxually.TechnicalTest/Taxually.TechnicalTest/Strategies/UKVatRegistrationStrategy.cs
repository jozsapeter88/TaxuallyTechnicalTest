using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Strategies;

public class UKVatRegistrationStrategy : IVatRegistrationStrategy
{
    private readonly TaxuallyHttpClient _httpClient;

    public UKVatRegistrationStrategy(TaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    
    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        try
        {
            await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during VAT registration: {ex.Message}");
            throw;
        }
    }
}