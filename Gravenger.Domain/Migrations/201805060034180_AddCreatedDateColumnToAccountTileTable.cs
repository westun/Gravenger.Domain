namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateColumnToAccountTileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountTile", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountTile", "CreatedDate");
        }
    }
}
