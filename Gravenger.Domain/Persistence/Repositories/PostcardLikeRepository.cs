using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class PostcardLikeRepository : Repository<PostcardLike>, IPostcardLikeRepository
    {
        public PostcardLikeRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public PostcardLike Get(int accountID, int postcardID)
        {
            return this.Context.PostcardLikes
                .Where(pcl => pcl.AccountID == accountID && pcl.PostcardID == postcardID)
                .FirstOrDefault();
        }

        public IEnumerable<PostcardLike> GetAllByPostcardID(int postcardID)
        {
            return this.Context.PostcardLikes
                .Where(pcl => pcl.PostcardID == postcardID)
                .ToList();
        }   

        public void Add(int accountID, int postcardID)
        {
            this.Context.PostcardLikes.Add(new PostcardLike {
                AccountID = accountID,
                PostcardID = postcardID,
            });
        }
    }
}
