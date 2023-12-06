using Taxually.TechnicalTest.Controllers;

namespace Taxually.TechnicalTest.Interfaces;

public interface IVatRegistrationStrategy
{
    Task RegisterAsync(VatRegistrationRequest request);
}