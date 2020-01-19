using System;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Dto
{
    public class CardDTO
    {
        public int CardID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public IEnumerable<PostcardDTO> Postcards { get; set; }
        public IEnumerable<TileDTO> Tiles { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
    }
}
