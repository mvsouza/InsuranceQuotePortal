using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{
    public class Motorcycle : Vehicle, IInsurable
    {

        protected override decimal GetFixedPercentage()
        {
            return 0.25m;
        }
    }
}
