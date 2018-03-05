using System;
using InsuranceQuotePortal.Domain;
using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Infrastructure.Repositories
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        IUnitOfWork UnitOfWork { get; }
    }
}
