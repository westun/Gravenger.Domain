using DevOne.Security.Cryptography.BCrypt;
using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly string version = System.Configuration.ConfigurationManager.AppSettings["Authentication.Version"].ToString();

        public AccountRepository(GravengerContext context)
            : base(context)
        {
        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }
        
        public Account GetByEmail(string email)
        {
            return this.Context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.Email == email);
        }
        
        public Account GetByUsername(string username)
        {
            return this.Context.Accounts
                .FirstOrDefault(a => a.Username == username);
        }

        public Account GetByUsernameWithCredentials(string username)
        {
            return this.Context.Accounts
                .Include(a => a.AccountCredentials)
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.Username == username);
        }

        public Account GetWithCredentials(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.AccountCredentials)
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public Account GetByUsernameWithRoles(string username)
        {
            return this.Context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.Username == username);
        }

        public Account GetWithRoles(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.Roles)
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public Account GetWithPostcards(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.Postcards)
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public Account GetWithFollowing(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.Followers.Select(f => f.Follower))
                .Include(a => a.Followees.Select(f => f.Followee))
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public Account GetWithPostcardsAndFollowing(int accountID)
        {
            return this.Context.Accounts
                .Include(a => a.Postcards.Select(pc => pc.Card.Tiles))
                .Include(a => a.Postcards.Select(pc => pc.PostcardLikes))
                //TODO: Consider if "AccountTiles" should not be used/accessible from "Account" domain model, 
                //      Instead only access through Postcards > PostcardTiles (AccountTiles) 
                //      So that Postcards act as an "Aggregate Root"?  
                //      (Changing name to "PostcardTiles" will help conceptualize this better)
                .Include(a => a.AccountTiles) 
                .Include(a => a.Followers.Select(f => f.Follower))
                .Include(a => a.Followees.Select(f => f.Followee))
                .FirstOrDefault(a => a.AccountID == accountID);
        }

        public void RemoveAccountRole(int accountID, int roleID)
        {
            var account = this.Get(accountID);
            var role = account.Roles.FirstOrDefault(r => r.RoleID == roleID);
            if (role != null)
            {
                account.Roles.Remove(role);
            }
        }

        public IEnumerable<Account> GetAllByCardID(int cardID)
        {
            //TODO: Should the account repository only being using "Accounts" as the root? (in this instance it is using Postcards)
            return this.Context.Postcards
                .Where(pc => pc.CardID == cardID)
                .OrderBy(pc => pc.Account.Username)
                .Select(pc => pc.Account)
                .ToList();
        }

        public IEnumerable<Account> GetAllThatLikePostcard(int postcardID)
        {
            //TODO: Should the account repository only being using "Accounts" as the root? (in this instance it is using Postcards)
            return this.Context.PostcardLikes
                .Where(pcl => pcl.PostcardID == postcardID)
                .OrderBy(pcl => pcl.Account.Username)
                .Select(pc => pc.Account)
                .ToList();
        }

        //TODO: Remove this method from the account repository, and instead use an expressive domain model
        public Account CreateAccount(Account account, out string errorMessage)
        {
            if (account == null)
            {
                errorMessage = "Please provide account information to create an account.";
                return null;
            }

            AccountCredential accountCredential = account.AccountCredentials.FirstOrDefault();
            if (accountCredential == null)
            {
                errorMessage = "Please provide a password to create an account.";
                return null;
            }
                
            if (string.IsNullOrWhiteSpace(account.Username))
            {
                errorMessage = "Please provide a username to create an account.";
                return null;
            }

            if (this.GetByUsername(account.Username) != null)
            {
                errorMessage = "An account with this username already exists.";
                return null;
            }

            if (this.GetByEmail(account.Email) != null)
            {
                errorMessage = "An account with this email address already exists.";
                return null;
            }

            string salt = BCryptHelper.GenerateSalt();
            string hashedPassword = BCryptHelper.HashPassword(accountCredential.Password, salt);

            accountCredential.Salt = salt;
            accountCredential.Password = hashedPassword;
            accountCredential.Version = this.version;
            accountCredential.Active = true;

            this.Context.Accounts.Add(account);
            this.Context.SaveChanges();

            errorMessage = null;
            return account;
        }
    }
}