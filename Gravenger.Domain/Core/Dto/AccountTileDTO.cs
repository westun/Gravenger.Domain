namespace Gravenger.Domain.Core.Dto
{
    public class AccountTileDTO
    {
        public int AccountTileID { get; set; }
        public int AccountID { get; set; }
        public int CardID { get; set; }
        public int TileID { get; set; }
        public string Title { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFullPath { get; set; }
    }
}
