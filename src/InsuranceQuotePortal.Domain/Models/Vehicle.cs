using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public abstract class Vehicle : IInsurable
    {

        protected abstract decimal GetFixedPercentage();

        public int Year { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - Year;
            }
        }
        public decimal Price { get; set; }
        public decimal CalculateQuote()
        {
            return Age >= 20 ? Price * GetFixedPercentage() : Price * (0.06m + 0.05m * Age);
        }
    }
}
