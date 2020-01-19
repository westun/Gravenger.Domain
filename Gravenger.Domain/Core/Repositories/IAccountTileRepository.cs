using Gravenger.Domain.Core.Models;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IAccountTileRepository : IRepository<AccountTile>
    {
        AccountTile Get(int accountID, int tileID);
        AccountTile GetWithAccountAndAccountTileLikes(int accountTileID);
    }
}
