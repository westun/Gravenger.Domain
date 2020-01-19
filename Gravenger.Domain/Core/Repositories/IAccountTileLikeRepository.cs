using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IAccountTileLikeRepository : IRepository<AccountTileLike>
    {
        AccountTileLike Get(int accountID, int accountTileID);
        IEnumerable<AccountTileLike> GetAllByAccountTileID(int accountTileID);
        void Add(int accountID, int accountTileID);
    }
}