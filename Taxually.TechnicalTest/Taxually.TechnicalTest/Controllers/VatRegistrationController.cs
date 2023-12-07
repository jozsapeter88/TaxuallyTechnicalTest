using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Models;


namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>

        private readonly IVatRegistrationStrategy _vatRegistrationStrategy;

        public VatRegistrationController(IVatRegistrationStrategy vatRegistrationStrategy)
        {
            _vatRegistrationStrategy = vatRegistrationStrategy ?? throw new ArgumentNullException(nameof(vatRegistrationStrategy));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            await _vatRegistrationStrategy.RegisterAsync(request);
            return Ok();
        }
    }
}
