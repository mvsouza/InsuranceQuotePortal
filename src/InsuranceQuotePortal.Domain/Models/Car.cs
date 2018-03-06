using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Models
{

    public class Car : Vehicle, IInsurable
    {
        protected override decimal GetFixedPercentage()
        {
            return 0.15m;
        }
    }
}
