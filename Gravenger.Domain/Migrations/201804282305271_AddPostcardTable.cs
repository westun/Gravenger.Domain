namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostcardTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardAccount", "Card_CardID", "dbo.Card");
            DropForeignKey("dbo.CardAccount", "Account_AccountID", "dbo.Account");
            DropIndex("dbo.CardAccount", new[] { "Card_CardID" });
            DropIndex("dbo.CardAccount", new[] { "Account_AccountID" });
            CreateTable(
                "dbo.Postcard",
                c => new
                    {
                        PostcardID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        CardID = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.PostcardID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Card", t => t.CardID)
                .Index(t => t.AccountID)
                .Index(t => t.CardID);
            
            AddColumn("dbo.AccountTile", "PostcardID", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountTile", "PostcardID");
            AddForeignKey("dbo.AccountTile", "PostcardID", "dbo.Postcard", "PostcardID");
            DropTable("dbo.CardAccount");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CardAccount",
                c => new
                    {
                        Card_CardID = c.Int(nullable: false),
                        Account_AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Card_CardID, t.Account_AccountID });
            
            DropForeignKey("dbo.AccountTile", "PostcardID", "dbo.Postcard");
            DropForeignKey("dbo.Postcard", "CardID", "dbo.Card");
            DropForeignKey("dbo.Postcard", "AccountID", "dbo.Account");
            DropIndex("dbo.Postcard", new[] { "CardID" });
            DropIndex("dbo.Postcard", new[] { "AccountID" });
            DropIndex("dbo.AccountTile", new[] { "PostcardID" });
            DropColumn("dbo.AccountTile", "PostcardID");
            DropTable("dbo.Postcard");
            CreateIndex("dbo.CardAccount", "Account_AccountID");
            CreateIndex("dbo.CardAccount", "Card_CardID");
            AddForeignKey("dbo.CardAccount", "Account_AccountID", "dbo.Account", "AccountID", cascadeDelete: true);
            AddForeignKey("dbo.CardAccount", "Card_CardID", "dbo.Card", "CardID", cascadeDelete: true);
        }
    }
}
