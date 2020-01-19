using Gravenger.Domain.Core;
using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Providers;
using Gravenger.Domain.Core.Security;
using System.Linq;
using System.Web.Security;

namespace Gravenger.Domain.Providers
{
    public class GravengerAuthProvider : IAuthProvider
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordEncryptor _passwordEncryptor;
        private readonly string version = System.Configuration.ConfigurationManager.AppSettings["Authentication.Version"].ToString();
        
        public GravengerAuthProvider(IUnitOfWork unitOfWork, IPasswordEncryptor passwordEncryptor)
        {
            this._unitOfWork = unitOfWork;
            this._passwordEncryptor = passwordEncryptor;
        }
        
        public bool Authenticate(string username, string password, bool createPersistentCookie = false)
        {
            Account account = this._unitOfWork.Accounts.GetByUsernameWithCredentials(username);
            if (account == null || account.AccountCredentials == null)
            {
                return false;
            }

            string storedPassword = account.AccountCredentials
                .FirstOrDefault(ac => ac.Version == this.version && ac.Active)?.Password;
            if (this._passwordEncryptor.VerifyPassword(password, storedPassword))
            {
                FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
                return true;
            }

            return false;
        }
        
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
