namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTileLikeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTileLike",
                c => new
                    {
                        AccountTileLikeID = c.Int(nullable: false, identity: true),
                        AccountTileID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.AccountTileLikeID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.AccountTile", t => t.AccountTileID)
                .Index(t => new { t.AccountID, t.AccountTileID }, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTileLike", "AccountTileID", "dbo.AccountTile");
            DropForeignKey("dbo.AccountTileLike", "AccountID", "dbo.Account");
            DropIndex("dbo.AccountTileLike", new[] { "AccountID", "AccountTileID" });
            DropTable("dbo.AccountTileLike");
        }
    }
}
