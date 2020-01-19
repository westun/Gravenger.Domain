using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class AccountTileLikeConfiguration : EntityTypeConfiguration<AccountTileLike>
    {
        public AccountTileLikeConfiguration()
        {
            this.HasKey(atl => atl.AccountTileLikeID);

            this.Property(atl => atl.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasRequired(atl => atl.Account)
                 .WithMany(a => a.AccountTileLikes)
                 .WillCascadeOnDelete(false);

            this.HasRequired(atl => atl.AccountTile)
                .WithMany(at => at.AccountTileLikes)
                .WillCascadeOnDelete(false);

            this.HasIndex(atl => new { atl.AccountID, atl.AccountTileID })
                .IsUnique();
        }
    }
}