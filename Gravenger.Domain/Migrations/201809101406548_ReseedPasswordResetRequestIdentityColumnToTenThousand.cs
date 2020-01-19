namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedPasswordResetRequestIdentityColumnToTenThousand : DbMigration
    {
        public override void Up()
        {
            this.Sql("IF IDENT_CURRENT('PasswordResetRequest') < 10000 DBCC CHECKIDENT('PasswordResetRequest', RESEED, 10000)");
        }
        
        public override void Down()
        {
            //This is mostly an operation that cannot be undone.
        }
    }
}
