namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCardIDColumnToNotificationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notification", "CardID", c => c.Int());
            CreateIndex("dbo.Notification", "CardID");
            AddForeignKey("dbo.Notification", "CardID", "dbo.Card", "CardID");

            this.Sql(@"
                UPDATE Notification
                SET CardID = (SELECT CardID FROM Card WHERE Title = CardTitle)
            ");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notification", "CardID", "dbo.Card");
            DropIndex("dbo.Notification", new[] { "CardID" });
            DropColumn("dbo.Notification", "CardID");
        }
    }
}
