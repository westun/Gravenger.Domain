namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateManyVarCharTypeColumnsToBeRequireOrHaveMaxLengthIfAppropriate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Account", "AccountUsernameIndex");
            DropIndex("dbo.EmailVerification", "EmailVerificationEmailIndex");
            DropIndex("dbo.EmailVerification", "EmailVerificationTokenIndex");
            DropIndex("dbo.Invitation", "InvitationEmailIndex");
            AlterColumn("dbo.Account", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Account", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Account", "Email", c => c.String(nullable: false, maxLength: 254));
            AlterColumn("dbo.Account", "Username", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AccountCredential", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.AccountCredential", "Salt", c => c.String(nullable: false));
            AlterColumn("dbo.AccountCredential", "Version", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Card", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Category", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tag", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tile", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EmailVerification", "Email", c => c.String(nullable: false, maxLength: 254));
            AlterColumn("dbo.EmailVerification", "Token", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Invitation", "Email", c => c.String(nullable: false, maxLength: 254));
            AlterColumn("dbo.Role", "Name", c => c.String(nullable: false, maxLength: 75));
            CreateIndex("dbo.Account", "Email", unique: true);
            CreateIndex("dbo.Account", "Username", unique: true);
            CreateIndex("dbo.EmailVerification", "Email");
            CreateIndex("dbo.EmailVerification", "Token");
            CreateIndex("dbo.Invitation", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Invitation", new[] { "Email" });
            DropIndex("dbo.EmailVerification", new[] { "Token" });
            DropIndex("dbo.EmailVerification", new[] { "Email" });
            DropIndex("dbo.Account", new[] { "Username" });
            DropIndex("dbo.Account", new[] { "Email" });
            AlterColumn("dbo.Role", "Name", c => c.String());
            AlterColumn("dbo.Invitation", "Email", c => c.String(maxLength: 254));
            AlterColumn("dbo.EmailVerification", "Token", c => c.String(maxLength: 100));
            AlterColumn("dbo.EmailVerification", "Email", c => c.String(maxLength: 254));
            AlterColumn("dbo.Tile", "Title", c => c.String());
            AlterColumn("dbo.Tag", "Name", c => c.String());
            AlterColumn("dbo.Category", "Title", c => c.String());
            AlterColumn("dbo.Card", "Title", c => c.String());
            AlterColumn("dbo.AccountCredential", "Version", c => c.String());
            AlterColumn("dbo.AccountCredential", "Salt", c => c.String());
            AlterColumn("dbo.AccountCredential", "Password", c => c.String());
            AlterColumn("dbo.Account", "Username", c => c.String(maxLength: 30));
            AlterColumn("dbo.Account", "Email", c => c.String(maxLength: 254));
            AlterColumn("dbo.Account", "LastName", c => c.String());
            AlterColumn("dbo.Account", "FirstName", c => c.String());
            CreateIndex("dbo.Invitation", "Email", unique: true, name: "InvitationEmailIndex");
            CreateIndex("dbo.EmailVerification", "Token", name: "EmailVerificationTokenIndex");
            CreateIndex("dbo.EmailVerification", "Email", name: "EmailVerificationEmailIndex");
            CreateIndex("dbo.Account", "Username", unique: true, name: "AccountUsernameIndex");
        }
    }
}
