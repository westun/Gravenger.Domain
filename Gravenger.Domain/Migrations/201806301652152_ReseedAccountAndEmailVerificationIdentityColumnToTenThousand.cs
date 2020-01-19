namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedAccountAndEmailVerificationIdentityColumnToTenThousand : DbMigration
    {
        public override void Up()
        {
            this.Sql("IF IDENT_CURRENT('EmailVerification') < 10000 DBCC CHECKIDENT('EmailVerification', RESEED, 10000)");
            this.Sql("IF IDENT_CURRENT('Account') < 10000 DBCC CHECKIDENT('Account', RESEED, 10000)");
        }

        public override void Down()
        {
            //This is mostly an operation that cannot be undone.
        }
    }
}
