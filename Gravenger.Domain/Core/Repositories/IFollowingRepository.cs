using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IFollowingRepository : IRepository<Following>
    {
        IEnumerable<Following> GetFolloweesWithAll(int accountID);
        IEnumerable<Following> GetFollowersWithAll(int accountID);
        void Add(int followeeID, int followerID);
        void Remove(int followeeID, int followerID);
    }
}
