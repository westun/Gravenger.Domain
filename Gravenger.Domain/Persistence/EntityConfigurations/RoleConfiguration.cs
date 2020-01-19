using Gravenger.Domain.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.HasKey(r => r.RoleID);

            this.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(75);
        }
    }
}