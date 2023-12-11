using System.Text;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Strategies;

public class FranceVatRegistrationStrategy : IVatRegistrationStrategy
{
    private readonly TaxuallyQueueClient _queueClient;

    public FranceVatRegistrationStrategy(TaxuallyQueueClient queueClient)
    {
        _queueClient = queueClient ?? throw new ArgumentNullException(nameof(queueClient));
    }

    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        try
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName}{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during VAT registration: {ex.Message}");
            throw;
        }
    }
}