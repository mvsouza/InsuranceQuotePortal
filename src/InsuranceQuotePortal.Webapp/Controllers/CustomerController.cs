using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Webapp.Application.Services;
using InsuranceQuotePortal.Webapp.Models;

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
            return View();
        }
        [HttpPost]
        public IActionResult New(Customer customer)
        {
            try
            {
                _customerService.Add(customer);

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
