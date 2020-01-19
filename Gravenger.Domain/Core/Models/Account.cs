using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Account
    {
        public Account()
        {
            this.AccountCredentials = new Collection<AccountCredential>();
            this.AccountNotifications = new Collection<AccountNotification>();
            this.AccountTiles = new Collection<AccountTile>();
            this.ActorNotifications = new Collection<Notification>();
            this.CreatedEmailVerifications = new Collection<EmailVerification>();
            this.CreatedInvitations = new Collection<Invitation>();
            this.EmailVerifications = new Collection<EmailVerification>();
            this.Invitations = new Collection<Invitation>();
            this.Followees = new Collection<Following>();
            this.Followers = new Collection<Following>();
            this.PostcardLikes = new Collection<PostcardLike>();
            this.Postcards = new Collection<Postcard>();
            this.Roles = new Collection<Role>();
        }

        public int AccountID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ProfileImageFileName { get; set; }
        public string ProfileImageFullPath { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }
        
        public virtual ICollection<AccountCredential> AccountCredentials { get; set; }
        public virtual ICollection<AccountNotification> AccountNotifications { get; set; }
        public virtual ICollection<AccountTile> AccountTiles { get; set; }
        public virtual ICollection<AccountTileLike> AccountTileLikes { get; set; }
        public virtual ICollection<Notification> ActorNotifications { get; set; }
        public virtual ICollection<EmailVerification> CreatedEmailVerifications { get; set; }
        public virtual ICollection<Invitation> CreatedInvitations { get; set; }
        public virtual ICollection<EmailVerification> EmailVerifications { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<Following> Followees { get; set; }
        public virtual ICollection<Following> Followers { get; set; }
        public virtual ICollection<PasswordResetRequest> PasswordResetRequests { get; set; }
        public virtual ICollection<PostcardLike> PostcardLikes { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public void Notify(Notification notification)
        {
            this.AccountNotifications.Add(new AccountNotification(this, notification));
        }
    }
}
