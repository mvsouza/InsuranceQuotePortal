using InsuranceQuotePortal.Domain;
using InsuranceQuotePortal.Domain.Models;
using InsuranceQuotePortal.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InsuranceQuotePortal.Infrastructure.Repositories
{
    public class ConsumedActionRepository : IConsumedActionRepository
    {
        public readonly QuotingContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ConsumedActionRepository(QuotingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Save(ConsumedAction consumedAction)
        {
            var toIncrement = _context.ConsumedAction
                                      .FirstOrDefault(a => a.UserName == consumedAction.UserName);
            if (toIncrement == null)
            {
                _context.ConsumedAction
                        .Add(consumedAction);
            }
            else
            {
                toIncrement.IncrementTimesHited();
                _context.ConsumedAction.Update(toIncrement);
            }
        }

        public IEnumerable<ConsumedAction> FromCustumer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsumedAction> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
