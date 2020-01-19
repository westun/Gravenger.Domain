namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingTableWithCreatedDate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountFollowing", "AccountFollowerID", "dbo.Account");
            DropForeignKey("dbo.AccountFollowing", "AccountFolloweeID", "dbo.Account");
            DropIndex("dbo.AccountFollowing", new[] { "AccountFollowerID" });
            DropIndex("dbo.AccountFollowing", new[] { "AccountFolloweeID" });
            CreateTable(
                "dbo.Following",
                c => new
                    {
                        FolloweeID = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => new { t.FolloweeID, t.FollowerID })
                .ForeignKey("dbo.Account", t => t.FollowerID)
                .ForeignKey("dbo.Account", t => t.FolloweeID)
                .Index(t => t.FolloweeID)
                .Index(t => t.FollowerID);
            
            DropTable("dbo.AccountFollowing");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccountFollowing",
                c => new
                    {
                        AccountFollowerID = c.Int(nullable: false),
                        AccountFolloweeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountFollowerID, t.AccountFolloweeID });
            
            DropForeignKey("dbo.Following", "FolloweeID", "dbo.Account");
            DropForeignKey("dbo.Following", "FollowerID", "dbo.Account");
            DropIndex("dbo.Following", new[] { "FollowerID" });
            DropIndex("dbo.Following", new[] { "FolloweeID" });
            DropTable("dbo.Following");
            CreateIndex("dbo.AccountFollowing", "AccountFolloweeID");
            CreateIndex("dbo.AccountFollowing", "AccountFollowerID");
            AddForeignKey("dbo.AccountFollowing", "AccountFolloweeID", "dbo.Account", "AccountID");
            AddForeignKey("dbo.AccountFollowing", "AccountFollowerID", "dbo.Account", "AccountID");
        }
    }
}
