﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceQuotePortal.Domain
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void SaveEntities(CancellationToken cancellationToken = default(CancellationToken));
    }
}
