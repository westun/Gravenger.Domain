using System;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Dto
{
    public class FeedItemDTOVer1Dot1
    {
        public string FeedItemType { get; set; }
        public string FolloweeUserName { get; set; }
        public string FolloweeProfileImageUrl { get; set; }
        public string FollowerUserName { get; set; }
        public string FollowerProfileImageUrl { get; set; }
        public int CardID { get; set; }
        public string CardTitle { get; set; }
        public string TileTitle { get; set; }
        public DateTimeOffset DateTimeStamp { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
    }
}
