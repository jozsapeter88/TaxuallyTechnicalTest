using Taxually.TechnicalTest.Models;

namespace Taxually.TechnicalTest.Interfaces;

public interface IVatRegistrationStrategy
{
    Task RegisterAsync(VatRegistrationRequest request);
}