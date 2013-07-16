using System.Data.Entity.ModelConfiguration;
using Liki.Domain.Core.Aggregates.UserAgg;

namespace Liki.Domain.Core.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        #region Constructors
        /// <summary>
        /// User map
        /// </summary>
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID );
            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserID).HasColumnName("UserID");
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
