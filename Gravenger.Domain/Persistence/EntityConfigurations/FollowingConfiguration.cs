using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            this.HasKey(f => new { f.FolloweeID, f.FollowerID });

            this.Property(f => f.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}