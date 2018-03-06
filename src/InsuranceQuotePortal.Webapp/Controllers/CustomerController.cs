using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Application.Services;
using InsuranceQuotePortal.Application.Models;
using InsuranceQuotePortal.Application.Models;

namespace InsuranceQuotePortal.Webapp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService _customerService){
            this._customerService = _customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            ViewBag.InsuranceProvidedList = new []{
                new {
                    value = InsuranceType.Car,
                    name = InsuranceType.Car.ToString()
                },
                new {
                    value = InsuranceType.MotorCycle,
                    name = InsuranceType.MotorCycle.ToString()
                },
                new {
                    value = InsuranceType.Farm,
                    name = InsuranceType.Farm.ToString()
                },
                new {
                    value = InsuranceType.House,
                    name = InsuranceType.House.ToString()
                }
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(NewCustomerViewModel customer)
        {
            try
            {

                Func<string,string,string> createUrl = (id, code) =>
                {
                    return Url.ResetPasswordCallbackLink(id, code, Request.Scheme);
                };
                await _customerService.AddAsync(customer, createUrl);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", "It was not possible to create a new cutomer, please try later on. (Business Msg Due to Circuit-Breaker)");
            }
            return View("Create",  customer);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
