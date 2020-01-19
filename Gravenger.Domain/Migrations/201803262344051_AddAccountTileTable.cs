namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTile",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        TileID = c.Int(nullable: false),
                        ImageFileName = c.String(),
                        ImageFullPath = c.String(),
                    })
                .PrimaryKey(t => new { t.AccountID, t.TileID })
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Tile", t => t.TileID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.TileID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTile", "TileID", "dbo.Tile");
            DropForeignKey("dbo.AccountTile", "AccountID", "dbo.Account");
            DropIndex("dbo.AccountTile", new[] { "TileID" });
            DropIndex("dbo.AccountTile", new[] { "AccountID" });
            DropTable("dbo.AccountTile");
        }
    }
}
