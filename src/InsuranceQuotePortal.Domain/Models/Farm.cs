using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public class Farm : IInsurable
    {
        public decimal SquareMeter { get; set; }
        public decimal Price { get; set; }
        public decimal CalculateQuote()
        {
            return Price * (0.002m + 0.00001m * SquareMeter);
        }
    }
}
