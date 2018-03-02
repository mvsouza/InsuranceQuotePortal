using System.Threading;
using System.Threading.Tasks;
using InsuranceQuotePortal.Domain;
using InsuranceQuotePortal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceQuotePortal.Infrastructure
{
    public class QuotingContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "quote";
        public DbSet<Customer> Customer { get; set; }

        private QuotingContext(DbContextOptions<QuotingContext> options) : base (options) { }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }       
    }
}