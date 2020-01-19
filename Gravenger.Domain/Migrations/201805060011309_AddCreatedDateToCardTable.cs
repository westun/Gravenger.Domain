namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateToCardTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Card", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Card", "CreatedDate");
        }
    }
}
