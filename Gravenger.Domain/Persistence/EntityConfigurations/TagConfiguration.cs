using Gravenger.Domain.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            this.HasKey(t => t.TagID);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            //TODO: Add all relationships to fluent api configuration
        }
    }
}