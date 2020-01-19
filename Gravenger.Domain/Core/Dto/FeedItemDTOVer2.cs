namespace Gravenger.Domain.Core.Dto
{
    public class FeedItemDTOVer2
    {
        public string FeedItemType { get; set; }
        public int ActorAccountID { get; set; }
        public string ActorUserName { get; set; }
        public string ActorProfileImageUrl { get; set; }
        public int FolloweeAccountID { get; set; }
        public string FolloweeUserName { get; set; }
        public string FolloweeProfileImageUrl { get; set; }
        public int FollowerAccountID { get; set; }
        public string FollowerUserName { get; set; }
        public string FollowerProfileImageUrl { get; set; }
        public int CardID { get; set; }
        public string CardTitle { get; set; }
    }
}
