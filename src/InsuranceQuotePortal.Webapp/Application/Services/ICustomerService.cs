using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public interface ICustomerService
    {
        Customer Add(Customer customer);
    }
}