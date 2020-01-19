namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 100),
                        Username = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.AccountCredential",
                c => new
                    {
                        AccountCredentialID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Password = c.String(),
                        Salt = c.String(),
                        Active = c.Boolean(nullable: false),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.AccountCredentialID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Account_AccountID = c.Int(),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.Account", t => t.Account_AccountID)
                .Index(t => t.Account_AccountID);
            
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Tile",
                c => new
                    {
                        TileID = c.Int(nullable: false, identity: true),
                        CardID = c.Int(nullable: false),
                        Title = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TileID)
                .ForeignKey("dbo.Card", t => t.CardID, cascadeDelete: true)
                .Index(t => t.CardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tile", "CardID", "dbo.Card");
            DropForeignKey("dbo.Card", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Role", "Account_AccountID", "dbo.Account");
            DropForeignKey("dbo.AccountCredential", "AccountID", "dbo.Account");
            DropIndex("dbo.Tile", new[] { "CardID" });
            DropIndex("dbo.Card", new[] { "Category_CategoryID" });
            DropIndex("dbo.Role", new[] { "Account_AccountID" });
            DropIndex("dbo.AccountCredential", new[] { "AccountID" });
            DropTable("dbo.Tile");
            DropTable("dbo.Category");
            DropTable("dbo.Card");
            DropTable("dbo.Role");
            DropTable("dbo.AccountCredential");
            DropTable("dbo.Account");
        }
    }
}
