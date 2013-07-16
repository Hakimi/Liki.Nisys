using System.Data.Entity;
using Liki.Domain.Core.Aggregates.UserAgg;
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

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        #endregion

        #region Method

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new TransactionMap());
        }

        #endregion
    }
}
