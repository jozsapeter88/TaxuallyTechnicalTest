using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Interfaces;

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
        await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
    }
}