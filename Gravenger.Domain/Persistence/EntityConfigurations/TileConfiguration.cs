using Gravenger.Domain.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class TileConfiguration : EntityTypeConfiguration<Tile>
    {
        public TileConfiguration()
        {
            this.HasKey(t => t.TileID);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}