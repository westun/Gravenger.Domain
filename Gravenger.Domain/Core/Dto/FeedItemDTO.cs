using System;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Dto
{
    public class FeedItemDTO
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTimeOffset DateTimeStamp { get; set; }
        public IEnumerable<string> ImageUrls { get; set; }
    }
}
