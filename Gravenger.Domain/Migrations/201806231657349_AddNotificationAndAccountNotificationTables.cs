namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationAndAccountNotificationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountNotification",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        NotificationID = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountID, t.NotificationID })
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Notification", t => t.NotificationID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.NotificationID);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        ActorAccountID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        CardTitle = c.String(maxLength: 100),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Account", t => t.ActorAccountID)
                .Index(t => t.ActorAccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notification", "ActorAccountID", "dbo.Account");
            DropForeignKey("dbo.AccountNotification", "NotificationID", "dbo.Notification");
            DropForeignKey("dbo.AccountNotification", "AccountID", "dbo.Account");
            DropIndex("dbo.Notification", new[] { "ActorAccountID" });
            DropIndex("dbo.AccountNotification", new[] { "NotificationID" });
            DropIndex("dbo.AccountNotification", new[] { "AccountID" });
            DropTable("dbo.Notification");
            DropTable("dbo.AccountNotification");
        }
    }
}
