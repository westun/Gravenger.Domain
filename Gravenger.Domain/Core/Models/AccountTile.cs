using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class AccountTile
    {
        public AccountTile()
        {
            this.AccountTileLikes = new Collection<AccountTileLike>();
        }

        public int AccountTileID { get; set; }
        public int AccountID { get; set; }
        public int TileID { get; set; }
        public int PostcardID { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFullPath { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<AccountTileLike> AccountTileLikes { get; set; }
        public virtual Postcard Postcard { get; set; }
        public virtual Tile Tile { get; set; }
    }
}
