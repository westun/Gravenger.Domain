using System.Collections.Generic;

namespace Gravenger.Domain.Core.Dto
{
    public class PostcardDTO
    {
        public int PostcardID { get; set; }
        public int AccountID { get; set; }
        public int CardID { get; set; }
        public string Title { get; set; }
        public bool IsMarkedCompleted { get; set; }
        
        //TODO: consider if "Likes" property should be flattened into a count, or if property "PostcardLikesDTO" should be added instead?
        public int Likes { get; set; }
        
        //TODO: consider if "Likes" property should be flattened/computed into a boolean value, 
        //      or if property "PostcardLikesDTO" should be added instead,
        //      and then can be determined by consumer of API?
        public bool IsLikedByCurrentUser { get; set; }
        
        //TODO: Consider if "PostcardLikeDTO" is even needed, or if data can be flattened in "PostcardDTO"?
        //public IEnumerable<PostcardLikeDTO> PostcardLikes { get; set; }
        
        //TODO: Consider creating a DTO called "PostcardTileDTO" to indicate they tiles for postcards (AccountTile in database)
        public IEnumerable<AccountTileDTO> Tiles { get; set; }
    }
}
