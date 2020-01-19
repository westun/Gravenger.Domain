namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveImageColumnsFromTile : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tile", "ImageFileName");
            DropColumn("dbo.Tile", "ImageFullPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tile", "ImageFullPath", c => c.String());
            AddColumn("dbo.Tile", "ImageFileName", c => c.String());
        }
    }
}
