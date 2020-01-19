using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class PostcardLikeConfiguration : EntityTypeConfiguration<PostcardLike>
    {
        public PostcardLikeConfiguration()
        {
            this.HasKey(pcl => pcl.PostcardLikeID);

            this.Property(pcl => pcl.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasRequired(pcl => pcl.Account)
                 .WithMany(a => a.PostcardLikes)
                 .WillCascadeOnDelete(false);

            this.HasRequired(pcl => pcl.Postcard)
                .WithMany(p => p.PostcardLikes)
                .WillCascadeOnDelete(false);

            this.HasIndex(pc => new { pc.AccountID, pc.PostcardID })
                .IsUnique();
        }
    }
}