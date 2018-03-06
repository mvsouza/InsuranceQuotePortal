using InsuranceQuotePortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Domain.Repositories
{
    public interface IActionConsumedRepository
    {
        IEnumerable<ActionConsumed> GetAll();
        void Add(ActionConsumed actionConsumed);
        IEnumerable<ActionConsumed> FromCustumer(Guid customerId);
    }
}
