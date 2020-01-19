namespace Gravenger.Domain.Core.Dto
{
    public class PostcardLikeDTO
    {
        //TODO: Consider if "PostcardLikeDTO" is even needed, or if data can be flattened in "PostcardDTO"?
        public int PostcardLikeID { get; set; }
        public int PostcardID { get; set; }
        public int AccountID { get; set; }
        //public DateTimeOffset CreatedDate { get; set; }
    }
}
