using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public interface ICustomerService
    {
        Customer Add(NewCustomerViewModel customer);
    }
}