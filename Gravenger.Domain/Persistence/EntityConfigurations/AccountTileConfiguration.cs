using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class AccountTileConfiguration : EntityTypeConfiguration<AccountTile>
    {
        public AccountTileConfiguration()
        {
            this.HasKey(at => at.AccountTileID);

            this.Property(at => at.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasRequired(at => at.Account)
                .WithMany(a => a.AccountTiles)
                .WillCascadeOnDelete(false);

            this.HasRequired(at => at.Tile)
                .WithMany(t => t.AccountTiles)
                .WillCascadeOnDelete(false);

            this.HasIndex(pc => new { pc.AccountID, pc.TileID })
                .IsUnique();

            this.HasRequired(at => at.Postcard)
                .WithMany(pc => pc.AccountTiles)
                .WillCascadeOnDelete(false);
        }
    }
}