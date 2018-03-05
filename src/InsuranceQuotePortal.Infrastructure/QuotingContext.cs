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

        public QuotingContext(DbContextOptions<QuotingContext> options) : base (options) { }


        public void SaveEntities(CancellationToken cancellationToken = default(CancellationToken))
        {
            base.SaveChanges();
            
        }       
    }
}