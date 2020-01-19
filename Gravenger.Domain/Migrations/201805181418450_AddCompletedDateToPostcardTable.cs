namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompletedDateToPostcardTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Postcard", "CompletedDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Postcard", "CompletedDate");
        }
    }
}
