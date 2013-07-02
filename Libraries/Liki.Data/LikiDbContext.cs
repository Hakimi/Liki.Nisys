using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using Liki.Core.Model;
using Liki.Core.Model.Mapping;

namespace Liki.Data
{
    public class LikiDbContext : DbContext 
    {
        static LikiDbContext()
        {
            Database.SetInitializer<LikiDbContext>(null);
        }

        public LikiDbContext()
            : base("Name=likidbContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new TransactionMap());
        }
    }
}
