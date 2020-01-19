namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToTileImageNameAndPathColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tile", "ImageFileName", c => c.String());
            AddColumn("dbo.Tile", "ImageFullPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tile", "ImageFullPath");
            DropColumn("dbo.Tile", "ImageFileName");
        }
    }
}
