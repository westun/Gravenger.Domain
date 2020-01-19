using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class FollowingRepository : Repository<Following>, IFollowingRepository
    {
        public FollowingRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        //TODO: revisit this method originally created to support feed ver1.0
        public IEnumerable<Following> GetFolloweesWithAll(int accountID)
        {
            return this.Context.Followings
                .Where(f => f.FollowerID == accountID)
                .Include(f => f.Follower)
                .Include(f => f.Followee.Followers)
                .Include(f => f.Followee.Followees.Select(followee => followee.Followee))
                .Include(f => f.Followee.PostcardLikes.Select(pcl => pcl.Postcard).Select(pc => pc.Card))
                .Include(f => f.Followee.AccountTiles.Select(at => at.Postcard.Card))
                .Include(f => f.Followee.AccountTiles.Select(at => at.Tile))
                .Include(f => f.Followee.Postcards.Select(p => p.Card))
                .ToList();
        }

        //TODO: revisit this method copied and altered from "GetFolloweesWithAll"
        public IEnumerable<Following> GetFollowersWithAll(int accountID)
        {
            return this.Context.Followings
                .Where(f => f.FolloweeID == accountID)
                .Include(f => f.Followee)
                .Include(f => f.Follower.Followers)
                .Include(f => f.Follower.Followees.Select(followee => followee.Followee))
                .Include(f => f.Follower.PostcardLikes.Select(pcl => pcl.Postcard).Select(pc => pc.Card))
                .Include(f => f.Follower.AccountTiles.Select(at => at.Postcard.Card))
                .Include(f => f.Follower.AccountTiles.Select(at => at.Tile))
                .Include(f => f.Follower.Postcards.Select(p => p.Card))
                .ToList();
        }

        public void Add(int followeeID, int followerID)
        {
            this.Context.Followings.Add(new Following
            {
                FolloweeID = followeeID,
                FollowerID = followerID,
            });
        }

        public void Remove(int followeeID, int followerID)
        {
            var following = this.Context.Followings
                .First(f => f.FolloweeID == followeeID && f.FollowerID == followerID);

            this.Context.Followings.Remove(following);
        }
    }
}
