namespace Gravenger.Domain.Core.Models.Reports
{
    public class TopLikedUser
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string ProfileImageFullPath { get; set; }
        public int TotalLikes { get; set; }
    }
}
