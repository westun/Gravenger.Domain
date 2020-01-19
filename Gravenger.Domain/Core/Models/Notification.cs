using System;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Models
{
    public class Notification
    {
        protected Notification()
        {
        }

        public Notification(NotificationType type, Account actorAccount)
            : this(type, actorAccount, null)
        {

        }

        public Notification(NotificationType type, Account actorAccount, Card card)
        {
            if (actorAccount == null)
            {
                throw new ArgumentNullException(nameof(actorAccount));
            }
            
            this.Type = type;
            this.ActorAccount = actorAccount;
            this.CardID = card?.CardID;
            this.CardTitle = card?.Title;
        }

        public int NotificationID { get; private set; }
        public int ActorAccountID { get; private set; }
        public NotificationType Type { get; private set; }
        public int? CardID { get; private set; }
        //TODO: Remove "CardTitle" since now "CardID" has been added as a foreign key reference to the Card table
        public string CardTitle { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public virtual ICollection<AccountNotification> AccountNotifications { get; set; }
        public virtual Account ActorAccount { get; private set; }
        public virtual Card Card { get; private set; }
    }
}