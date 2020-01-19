using System;

namespace Gravenger.Domain.Core.Models
{
    public class EmailVerification
    {
        public EmailVerification()
        {
            this.Token = this.GenerateToken();
        }

        public int EmailVerificationID { get; set; }
        public int? AccountID { get; set; }
        public string Email { get; set; }
        public string Token { get; private set; }
        public bool Used { get; set; }
        public DateTimeOffset Expires { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public int? CreatedByAccountID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account CreatedByAccount { get; set; }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }

        public bool IsExpired
        {
            get
            {
                return DateTimeOffset.UtcNow > this.Expires;
            }
        }

        public bool IsValid
        {
            get
            {
                return !this.IsExpired && !this.Used;
            }
        }
    }
}
