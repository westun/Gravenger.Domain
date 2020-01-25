using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class PostcardConfiguration : EntityTypeConfiguration<Postcard>
    {
        public PostcardConfiguration()
        {
            this.HasKey(pc => pc.PostcardID);

            this.Property(pc => pc.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasRequired(pc => pc.Account)
                .WithMany(a => a.Postcards)
                .WillCascadeOnDelete(false);

            this.HasRequired(pc => pc.Card)
                .WithMany(c => c.Postcards)
                .WillCascadeOnDelete(false);

            this.HasIndex(pc => new { pc.AccountID, pc.CardID })
                .IsUnique();
        }
    }
}