using System;

namespace Gravenger.Domain.Core.Models
{
    public class AccountNotification
    {
        protected AccountNotification()
        {

        }

        public AccountNotification(Account account, Notification notification)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            this.Account = account;
            this.Notification = notification;
        }

        public int AccountID { get; private set; }
        public int NotificationID { get; private set; }
        public bool IsRead { get; set; }

        public virtual Account Account { get; private set; }
        public virtual Notification Notification { get; private set; }
    }
}