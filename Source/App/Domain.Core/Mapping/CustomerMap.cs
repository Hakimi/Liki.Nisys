using System.Data.Entity.ModelConfiguration;
using Liki.Domain.Core.Aggregates.CustomerAgg;

namespace Liki.Domain.Core.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        #region Constructors
        /// <summary>
        /// Customer map
        /// </summary>
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID );
            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
            this.Property(t => t.Password).HasColumnName("Password");

        }
        #endregion
    }
}
