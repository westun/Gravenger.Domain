using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Card
    {
        public Card()
        {
            this.Postcards = new Collection<Postcard>();
            this.Tags = new Collection<Tag>();
            this.Tiles = new Collection<Tile>();
        }

        public int CardID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; private set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Postcard> Postcards { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Tile> Tiles { get; set; }
    }
}