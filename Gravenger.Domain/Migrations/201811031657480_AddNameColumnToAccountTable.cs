namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToAccountTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Name", c => c.String());

            this.Sql("UPDATE Account Set Name = FirstName + ' ' + LastName WHERE Name IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Name");
        }
    }
}
