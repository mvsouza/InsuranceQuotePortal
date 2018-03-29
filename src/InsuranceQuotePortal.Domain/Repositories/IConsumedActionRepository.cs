using InsuranceQuotePortal.Domain.Models;
using System;
using System.Collections.Generic;

namespace InsuranceQuotePortal.Domain.Repositories
{
    public interface IConsumedActionRepository
    {
        IUnitOfWork UnitOfWork { get; }
        IEnumerable<ConsumedAction> GetAll();
        void Save(ConsumedAction consumedAction);
        IEnumerable<ConsumedAction> FromCustumer(Guid customerId);
    }
}
