using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Cards = new Collection<Card>();
        }

        public int TagID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}