using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class AccountTileLikeRepository : Repository<AccountTileLike>, IAccountTileLikeRepository
    {
        public AccountTileLikeRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public AccountTileLike Get(int accountID, int accountTileID)
        {
            return this.Context.AccountTileLikes
                .Where(atl => atl.AccountID == accountID && atl.AccountTileID == accountTileID)
                .FirstOrDefault();
        }

        public IEnumerable<AccountTileLike> GetAllByAccountTileID(int accountTileID)
        {
            return this.Context.AccountTileLikes
                .Where(atl => atl.AccountTileID == accountTileID)
                .ToList();
        }

        public void Add(int accountID, int accountTileID)
        {
            this.Context.AccountTileLikes.Add(new AccountTileLike {
                AccountID = accountID,
                AccountTileID = accountTileID,
            });
        }
    }
}
