using System.Xml.Serialization;
using Taxually.TechnicalTest.Controllers;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Strategies;

public class GermanyVatRegistrationStrategy : IVatRegistrationStrategy
{
    private readonly TaxuallyQueueClient _queueClient;

    public GermanyVatRegistrationStrategy(TaxuallyQueueClient queueClient)
    {
        _queueClient = queueClient ?? throw new ArgumentNullException(nameof(queueClient));
    }

    public async Task RegisterAsync(VatRegistrationRequest request)
    {
        using (var stringWriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
            serializer.Serialize(stringWriter, request);
            var xml = stringWriter.ToString();
            await _queueClient.EnqueueAsync("vat-registration-xml", xml);
        }
    }
}