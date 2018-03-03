using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Domain.Repositories;
using InsuranceQuotePortal.Infrastructure.Repositories;
using InsuranceQuotePortal.Webapp.Application.Models;
using System;
using System.Linq;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public class CustomerService : ICustomerService
    {

        public ICustomerRepository _repository;
        public CustomerService(ICustomerRepository _repository){
            this._repository = _repository;
        }
        public Customer Add(NewCustomerViewModel customer){
            var newCustomer = new Customer()
            {
                Address = customer.Address,
                CreatedAt = DateTime.Now,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone,
                InsuranceProvided = customer.InsuranceProvided.Select(
                    t => new CustumerInsuranceProveded() {
                        InsuranceProvided = t
                    })
            };
            return _repository.Add(newCustomer);
        }
    }
}