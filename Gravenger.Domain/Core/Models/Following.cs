using System;

namespace Gravenger.Domain.Core.Models
{
    public class Following
    {
        public int FolloweeID { get; set; }
        public int FollowerID { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public Account Followee { get; set; }
        public Account Follower { get; set; }
    }
}
