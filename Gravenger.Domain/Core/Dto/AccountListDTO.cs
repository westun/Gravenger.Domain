namespace Gravenger.Domain.Core.Dto
{
    public class AccountListDTO
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ProfileImageFullPath { get; set; }
        public bool CurrentUserIsFollowing { get; set; }
        public bool CurrentUserIsFollowed { get; set; }
    }
}
