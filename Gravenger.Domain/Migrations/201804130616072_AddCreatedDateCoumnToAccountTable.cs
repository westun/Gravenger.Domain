namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDateCoumnToAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"));
        }

        public override void Down()
        {
            DropColumn("dbo.Account", "CreatedDate");
        }
    }
}
