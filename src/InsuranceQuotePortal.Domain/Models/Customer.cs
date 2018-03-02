using System;
using System.Collections.Generic;
namespace InsuranceQuotePortal.Domain.Models
{
    public class Customer{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get ; set; }
        public ICollection<InsuranceType> InsuranceProvided { get; set; }
    }
}