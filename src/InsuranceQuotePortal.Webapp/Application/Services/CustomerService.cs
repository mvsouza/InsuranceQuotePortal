using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Infrastructure.Repositories;
using InsuranceQuotePortal.Webapp.Application.Models;
using InsuranceQuotePortal.Webapp.Models;
using InsuranceQuotePortal.Webapp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal.Networking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Webapp.Application.Services
{
    public class CustomerService : ICustomerService
    {

        public ICustomerRepository _repository;
        private UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public CustomerService(ICustomerRepository _repository, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            this._repository = _repository;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        public async Task<Customer> AddAsync(NewCustomerViewModel customer, Func<string, string, string> createUrl)
        {
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
                    }).ToList()
            };
            var returnValue = _repository.Add(newCustomer);
            
            var user = new ApplicationUser { UserName = customer.Email, Email = customer.Email };
            var result = await _userManager.CreateAsync(user, $"{customer.GetHashCode().ToString()}@Abc");

            if(result.Succeeded)
                _repository.UnitOfWork.SaveEntities();

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _emailSender.SendEmailAsync(customer.Email, "Create Password",
               $"Please create your password by clicking here: <a href='{createUrl(user.Id, code)}'>link</a>");
            return returnValue;
        }
    }
}