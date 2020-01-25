using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class CardConfiguration : EntityTypeConfiguration<Card>
    {
        public CardConfiguration()
        {
            this.HasKey(c => c.CardID);

            this.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(c => c.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}