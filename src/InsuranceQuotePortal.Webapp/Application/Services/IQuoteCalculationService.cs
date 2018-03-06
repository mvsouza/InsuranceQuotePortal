using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Application.Services
{
    public interface IQuoteCalculationService
    {
        decimal Calculate<Tv, Tm>(Tv viewModel) where Tm : IInsurable;
    }
}
