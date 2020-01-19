using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            this.HasKey(a => a.AccountID);

            this.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(a => a.FirstName)
                .HasMaxLength(50);

            this.Property(a => a.LastName)
                .HasMaxLength(50);

            this.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(a => a.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasMany(a => a.Followers)
                .WithRequired(f => f.Followee)
                .HasForeignKey(f => f.FolloweeID)
                .WillCascadeOnDelete(false);

            this.HasMany(a => a.Followees)
                .WithRequired(f => f.Follower)
                .HasForeignKey(f => f.FollowerID)
                .WillCascadeOnDelete(false);

            this.HasIndex(a => a.Email)
                .IsUnique();

            this.HasIndex(a => a.Username)
                .IsUnique();
        }
    }
}