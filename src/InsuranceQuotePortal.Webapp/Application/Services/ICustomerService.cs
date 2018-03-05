using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Models;
using System;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(NewCustomerViewModel customer, Func<string, string, string> createUrl);
    }
}