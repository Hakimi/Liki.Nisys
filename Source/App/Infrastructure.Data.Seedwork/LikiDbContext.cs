using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using Liki.Domain.Core.Aggregates.CustomerAgg;
using Liki.Domain.Core.Aggregates.LeaseAgg;
using Liki.Domain.Core.Mapping;

namespace Liki.Infrastructure.Data.Seedwork
{
    public class LikiDbContext : DbContext
    {
        #region Constructors
        
        static LikiDbContext()
        {
            Database.SetInitializer<LikiDbContext>(null);
        }

        public LikiDbContext()
            : base("Name=likidbContext")
        {
        }
        #endregion

        #region Property
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        #region Method
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new TransactionMap());
        }
        #endregion
    }
}
