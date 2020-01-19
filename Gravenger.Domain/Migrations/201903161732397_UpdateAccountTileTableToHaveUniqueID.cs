namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountTileTableToHaveUniqueID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountTile", "AccountID", "dbo.Account");
            DropForeignKey("dbo.AccountTile", "TileID", "dbo.Tile");
            DropIndex("dbo.AccountTile", new[] { "AccountID" });
            DropIndex("dbo.AccountTile", new[] { "TileID" });
            DropPrimaryKey("dbo.AccountTile");
            AddColumn("dbo.AccountTile", "AccountTileID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AccountTile", "AccountTileID");
            CreateIndex("dbo.AccountTile", new[] { "AccountID", "TileID" }, unique: true);
            AddForeignKey("dbo.AccountTile", "AccountID", "dbo.Account", "AccountID");
            AddForeignKey("dbo.AccountTile", "TileID", "dbo.Tile", "TileID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTile", "TileID", "dbo.Tile");
            DropForeignKey("dbo.AccountTile", "AccountID", "dbo.Account");
            DropIndex("dbo.AccountTile", new[] { "AccountID", "TileID" });
            DropPrimaryKey("dbo.AccountTile");
            DropColumn("dbo.AccountTile", "AccountTileID");
            AddPrimaryKey("dbo.AccountTile", new[] { "AccountID", "TileID" });
            CreateIndex("dbo.AccountTile", "TileID");
            CreateIndex("dbo.AccountTile", "AccountID");
            AddForeignKey("dbo.AccountTile", "TileID", "dbo.Tile", "TileID", cascadeDelete: true);
            AddForeignKey("dbo.AccountTile", "AccountID", "dbo.Account", "AccountID", cascadeDelete: true);
        }
    }
}
