namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSentDateColumnToInvitationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invitation", "SentDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invitation", "SentDate");
        }
    }
}
