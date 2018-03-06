using InsuranceQuotePortal.Application.Services;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuotePortal.Webapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Quote")]
    public class QuoteController : Controller
    {
        private IQuoteCalculationService _quoteCalculatetionService;
        public QuoteController(IQuoteCalculationService quoteCalculatetionService)
        {
            _quoteCalculatetionService = quoteCalculatetionService;
        }
        [HttpPost]
        public decimal CalculateMotorcycleQuote(VehicleViewModel car)
        {
            return _quoteCalculatetionService.Calculate<VehicleViewModel, Motorcycle>(car);
        }
        [HttpPost]
        public decimal CalculateCarQuote(VehicleViewModel car)
        {
            return _quoteCalculatetionService.Calculate<VehicleViewModel, Car>(car);
        }
        [HttpPost]
        public decimal CalculateFarmQuote(FarmViewModel farm)
        {
            return _quoteCalculatetionService.Calculate<FarmViewModel, Farm>(farm);
        }
        [HttpPost]
        public decimal CalculateHouseQuote(HouseViewModel house)
        {
            return _quoteCalculatetionService.Calculate<HouseViewModel, House>(house);
        }
    }
}