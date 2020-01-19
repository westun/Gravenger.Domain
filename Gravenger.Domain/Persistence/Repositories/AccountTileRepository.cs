using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class AccountTileRepository : Repository<AccountTile>, IAccountTileRepository
    {
        public AccountTileRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public AccountTile Get(int accountID, int tileID)
        {
            return this.Context.AccountTiles.Find(accountID, tileID);
        }

        public AccountTile GetWithAccountAndAccountTileLikes(int accountTileID)
        {
            return this.Context.AccountTiles
                .Include(at => at.Account)
                .Include(at => at.AccountTileLikes)
                .FirstOrDefault(at => at.AccountTileID == accountTileID);
        }
    }
}
