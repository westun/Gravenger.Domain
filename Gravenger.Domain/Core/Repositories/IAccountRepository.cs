using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByEmail(string email);
        Account GetByUsername(string username);
        Account GetByUsernameWithCredentials(string username);
        Account GetWithCredentials(int accountID);
        Account GetByUsernameWithRoles(string username);
        Account GetWithRoles(int accountID);
        Account GetWithPostcards(int accountID);
        Account GetWithFollowing(int accountID);
        Account GetWithPostcardsAndFollowing(int accountID);
        void RemoveAccountRole(int accountID, int roleID);
        IEnumerable<Account> GetAllByCardID(int cardID);
        IEnumerable<Account> GetAllThatLikePostcard(int postcardID);
        //TODO: Remove CreateAccount from repository.  Repository should only be a collection of object, no persistence.
        Account CreateAccount(Account account, out string errorMessage);
    }
}