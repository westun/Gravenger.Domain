using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class PostcardRepository : Repository<Postcard>, IPostcardRepository
    {
        public PostcardRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public Postcard Get(int accountID, int cardID)
        {
            return this.Context.Postcards
                .FirstOrDefault(pc => pc.AccountID == accountID && pc.CardID == cardID);
        }

        public Postcard GetWithAccountTiles(int accountID, int cardID)
        {
            return this.Context.Postcards
                .Where(pc => pc.AccountID == accountID && pc.CardID == cardID)
                .Include(pc => pc.AccountTiles)
                .FirstOrDefault();
        }

        public Postcard GetWithAccountAndPostcardLikes(int postcardID)
        {
            return this.Context.Postcards
                .Include(pc => pc.Account)
                .Include(pc => pc.Card)
                .Include(pc => pc.PostcardLikes)
                .FirstOrDefault(pc => pc.PostcardID == postcardID);
        }

        public IEnumerable<Postcard> GetTopLiked(int accountID)
        {
            return this.Context.Postcards
                .Include(pc => pc.Card)
                .Include(pc => pc.PostcardLikes)
                .Where(pc => pc.AccountID == accountID)
                .OrderByDescending(pc => pc.PostcardLikes.Count())
                .ToList();
        }

        public void Add(int accountID, int cardID)
        {
            this.Context.Postcards.Add(new Postcard {
                AccountID = accountID,
                CardID = cardID,
            });
        }
    }
}
