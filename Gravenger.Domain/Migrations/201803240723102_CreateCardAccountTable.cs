namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCardAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardAccount",
                c => new
                    {
                        Card_CardID = c.Int(nullable: false),
                        Account_AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Card_CardID, t.Account_AccountID })
                .ForeignKey("dbo.Card", t => t.Card_CardID, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_AccountID, cascadeDelete: true)
                .Index(t => t.Card_CardID)
                .Index(t => t.Account_AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardAccount", "Account_AccountID", "dbo.Account");
            DropForeignKey("dbo.CardAccount", "Card_CardID", "dbo.Card");
            DropIndex("dbo.CardAccount", new[] { "Account_AccountID" });
            DropIndex("dbo.CardAccount", new[] { "Card_CardID" });
            DropTable("dbo.CardAccount");
        }
    }
}
