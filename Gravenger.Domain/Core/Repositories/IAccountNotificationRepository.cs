using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IAccountNotificationRepository : IRepository<AccountNotification>
    {
        IEnumerable<AccountNotification> GetAllWithNotifications(int accountID);
        IEnumerable<AccountNotification> GetAllUnreadNotifications(int accountID);
    }
}
