using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Application.Models;
using System;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Application.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(NewCustomerViewModel customer, Func<string, string, string> createUrl);
    }
}