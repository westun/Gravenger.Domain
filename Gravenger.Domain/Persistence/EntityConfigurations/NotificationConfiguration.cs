using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            this.HasKey(n => n.NotificationID);

            this.Property(n => n.CardTitle)
                .HasMaxLength(100);

            this.Property(c => c.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasRequired(n => n.ActorAccount)
                .WithMany(a => a.ActorNotifications)
                .HasForeignKey(n => n.ActorAccountID)
                .WillCascadeOnDelete(false);
        }
    }
}