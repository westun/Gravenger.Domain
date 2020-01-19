using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class AccountNotificationConfiguration : EntityTypeConfiguration<AccountNotification>
    {
        public AccountNotificationConfiguration()
        {
            this.HasKey(at => new { at.AccountID, at.NotificationID });
        }
    }
}