using System;
using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
    }
}
