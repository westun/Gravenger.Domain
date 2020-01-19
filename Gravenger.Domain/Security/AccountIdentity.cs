using System.Security.Principal;

namespace Gravenger.Domain.Security
{
    public class AccountIdentity : GenericIdentity
    {
        private readonly int _accountID;

        public AccountIdentity(string name, string type, int accountID) 
            : base(name, type)
        {
            _accountID = accountID;
        }

        public int AccountID
        {
            get { return _accountID; }
        }
    }
}
