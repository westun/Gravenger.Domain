using Gravenger.Domain.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.HasKey(c => c.CategoryID);

            this.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            //TODO: add unique constraint for "Title"
        }
    }
}