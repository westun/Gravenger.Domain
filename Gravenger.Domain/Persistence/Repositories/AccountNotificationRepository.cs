using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class AccountNotificationRepository : Repository<AccountNotification>, IAccountNotificationRepository
    {
        public AccountNotificationRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public IEnumerable<AccountNotification> GetAllWithNotifications(int accountID)
        {
            return this.Context.AccountNotifications
                .Where(an => an.AccountID == accountID)
                .Include(an => an.Notification.ActorAccount)
                .ToList();
        }

        public IEnumerable<AccountNotification> GetAllUnreadNotifications(int accountID)
        {
            return this.Context.AccountNotifications
                .Where(an => an.AccountID == accountID && !an.IsRead)
                .ToList();
        }
    }
}
