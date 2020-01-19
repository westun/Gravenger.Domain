namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountFollowerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountFollower",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountID, t.FollowerID })
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Account", t => t.FollowerID)
                .Index(t => t.AccountID)
                .Index(t => t.FollowerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountFollower", "FollowerID", "dbo.Account");
            DropForeignKey("dbo.AccountFollower", "AccountID", "dbo.Account");
            DropIndex("dbo.AccountFollower", new[] { "FollowerID" });
            DropIndex("dbo.AccountFollower", new[] { "AccountID" });
            DropTable("dbo.AccountFollower");
        }
    }
}
