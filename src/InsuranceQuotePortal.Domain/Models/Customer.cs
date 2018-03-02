using System;
using System.Collections.Generic;
namespace InsuranceQuotePortal.Domain.Models
{
    public class CustumerInsuranceProveded
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public InsuranceType InsuranceProvided { get; set; }
    }
    public class Customer{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get ; set; }
        public ICollection<CustumerInsuranceProveded> InsuranceProvided { get; set; }
    }
}