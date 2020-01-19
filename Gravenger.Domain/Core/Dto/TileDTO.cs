namespace Gravenger.Domain.Core.Dto
{
    public class TileDTO
    {
        public int TileID { get; set; }
        public int CardID { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFullPath { get; set; }
    }
}
