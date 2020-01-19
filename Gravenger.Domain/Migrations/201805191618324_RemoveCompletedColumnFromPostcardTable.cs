namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCompletedColumnFromPostcardTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Postcard", "Completed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Postcard", "Completed", c => c.Boolean(nullable: false));
        }
    }
}
