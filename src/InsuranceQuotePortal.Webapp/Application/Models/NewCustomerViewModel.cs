using InsuranceQuotePortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Application.Models
{
    public class NewCustomerViewModel
    {
        public string Name { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IEnumerable<InsuranceType> InsuranceProvided { get; set; }
    }
}
