using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Liki.Core.Model.Mapping
{
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TransactionFID)
                .HasMaxLength(20);

            this.Property(t => t.Type)
                .HasMaxLength(20);

            this.Property(t => t.ProductLease_ID)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Transaction");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TransactionFID).HasColumnName("TransactionFID");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.ProductLease_ID).HasColumnName("ProductLeaseID");
            this.Property(t => t.Time).HasColumnName("Time");
        }
    }
}
