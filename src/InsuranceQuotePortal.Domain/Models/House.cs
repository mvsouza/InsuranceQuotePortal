using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public class House : IInsurable
    {
        public decimal Price { get; set; }
        public decimal CalculateQuote()
        {
            return Price * 0.02m;
        }
    }
}
