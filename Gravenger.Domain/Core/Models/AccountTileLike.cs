using System;

namespace Gravenger.Domain.Core.Models
{
    public class AccountTileLike
    {
        public int AccountTileLikeID { get; private set; }
        public int AccountTileID { get; set; }
        public int AccountID { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public Account Account { get; set; }
        public AccountTile AccountTile { get; set; }
    }
}
