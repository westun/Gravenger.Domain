using System;

namespace Gravenger.Domain.Core.Models
{
    public class Invitation
    {
        public int InvitationID { get; set; }
        public int? AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Accepted { get; set; }
        public DateTimeOffset? SentDate { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public int CreatedByAccountID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account CreatedByAccount { get; set; }

        public void MarkSent()
        {
            this.SentDate = DateTimeOffset.UtcNow;
        }
    }
}
