using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Liki.Core.Model.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID );

            // Properties
            //this.Property(t => t.ID)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //this.Property(t => t.FirstName)
            //    .HasMaxLength(20);

            //this.Property(t => t.LastName)
            //    .HasMaxLength(20);

            //this.Property(t => t.CustomerFID)
            //    .HasMaxLength(20);



            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            
            
        }
    }
}
