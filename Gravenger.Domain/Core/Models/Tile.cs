using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Tile
    {
        public Tile()
        {
            this.AccountTiles = new Collection<AccountTile>();
        }

        public int TileID { get; set; }
        public int CardID { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }

        public virtual ICollection<AccountTile> AccountTiles { get; set; }
        public virtual Card Card { get; set; }
    }
}