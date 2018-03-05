using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using InsuranceQuotePortal.Domain;
using InsuranceQuotePortal.Infrastructure.Repositories;
using InsuranceQuotePortal.Infrastructure;
using InsuranceQuotePortal.Domain.Models;

namespace InsuranceQuotePortal.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly QuotingContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public CustomerRepository(QuotingContext context){
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Customer Add(Customer customer){

            return _context.Customer
                .Add(customer)
                .Entity;
        }
    }
}
