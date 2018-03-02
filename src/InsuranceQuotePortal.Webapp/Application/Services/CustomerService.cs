using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Domain.Repositories;
using InsuranceQuotePortal.Infrastructure.Repositories;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public class CustomerService : ICustomerService
    {

        public ICustomerRepository _repository;
        public CustomerService(ICustomerRepository _repository){
            this._repository = _repository;
        }
        public Customer Add(Customer customer){
            return _repository.Add(customer);
        }
    }
}