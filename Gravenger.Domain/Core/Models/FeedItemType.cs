namespace Gravenger.Domain.Core.Models
{
    //TODO: could use polymorphism instead of enum (i.e.: IFeedItem)
    public enum FeedItemType
    {
        FolloweeAddedCard = 0,
        FolloweeCompletedCard = 1,
        FolloweeLikedCard = 2,
        FolloweeAddedTile = 3,
        FolloweeFollowed = 4,
        YouFollowed = 5,
        FollowedYou = 6,
        UserJoined = 7,
        FolloweeLikedYourCard = 8,
        YouLikedFolloweesCard = 9,
        YouAddedTile = 10,
        YouCompletedCard = 11,
    }
}
