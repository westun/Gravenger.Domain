using System;

namespace Gravenger.Domain.Core.Models
{
    public class PostcardLike
    {
        public int PostcardLikeID { get; private set; }
        public int PostcardID { get; set; }
        public int AccountID { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public Account Account { get; set; }
        public Postcard Postcard { get; set; }
    }
}
