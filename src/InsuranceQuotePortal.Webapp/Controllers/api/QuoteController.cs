using InsuranceQuotePortal.Application.Services;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;
using InsuranceQuotePortal.Webapp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuotePortal.Webapp.api.Controllers
{
    [Produces("application/json")]
    [Route("api/Quote/[action]")]
    [Authorize]
    [TypeFilter(typeof(ConsumedActionByFilter))]
    public class QuoteController : Controller
    {
        private IQuoteCalculationService _quoteCalculatetionService;
        public QuoteController(IQuoteCalculationService quoteCalculatetionService)
        {
            _quoteCalculatetionService = quoteCalculatetionService;
        }
        [HttpPost]
        [Route("api/Quote/CalculateMotorcycle")]
        public decimal CalculateMotorcycleQuote([FromBody]VehicleViewModel car)
        {
            return _quoteCalculatetionService.Calculate<VehicleViewModel, Motorcycle>(car);
        }
        [HttpPost]
        public decimal CalculateCarQuote([FromBody]VehicleViewModel car)
        {
            return _quoteCalculatetionService.Calculate<VehicleViewModel, Car>(car);
        }
        [HttpPost]
        public decimal CalculateFarmQuote([FromBody]FarmViewModel farm)
        {
            return _quoteCalculatetionService.Calculate<FarmViewModel, Farm>(farm);
        }
        [HttpPost]
        public decimal CalculateHouseQuote([FromBody]HouseViewModel house)
        {
            return _quoteCalculatetionService.Calculate<HouseViewModel, House>(house);
        }
    }
}