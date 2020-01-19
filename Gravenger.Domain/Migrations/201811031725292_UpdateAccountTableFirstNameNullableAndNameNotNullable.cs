namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountTableFirstNameNullableAndNameNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "FirstName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            this.Sql(@"
                UPDATE Account 
                Set FirstName = ''
                WHERE FirstName IS NULL");

            this.Sql(@"
                UPDATE Account 
                Set LastName = ''
                WHERE LastName IS NULL");

            AlterColumn("dbo.Account", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "Name", c => c.String());
        }
    }
}
