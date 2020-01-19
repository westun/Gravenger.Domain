namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailVerificationAndInvitationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailVerification",
                c => new
                    {
                        EmailVerificationID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(),
                        Email = c.String(maxLength: 254),
                        Token = c.String(maxLength: 100),
                        Used = c.Boolean(nullable: false),
                        Expires = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                        CreatedByAccountID = c.Int(),
                    })
                .PrimaryKey(t => t.EmailVerificationID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Account", t => t.CreatedByAccountID)
                .Index(t => t.AccountID)
                .Index(t => t.Email, name: "EmailVerificationEmailIndex")
                .Index(t => t.Token, name: "EmailVerificationTokenIndex")
                .Index(t => t.CreatedByAccountID);
            
            CreateTable(
                "dbo.Invitation",
                c => new
                    {
                        InvitationID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(),
                        FirstName = c.String(maxLength: 80),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 254),
                        Accepted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                        CreatedByAccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Account", t => t.CreatedByAccountID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.Email, unique: true, name: "InvitationEmailIndex")
                .Index(t => t.CreatedByAccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invitation", "CreatedByAccountID", "dbo.Account");
            DropForeignKey("dbo.Invitation", "AccountID", "dbo.Account");
            DropForeignKey("dbo.EmailVerification", "CreatedByAccountID", "dbo.Account");
            DropForeignKey("dbo.EmailVerification", "AccountID", "dbo.Account");
            DropIndex("dbo.Invitation", new[] { "CreatedByAccountID" });
            DropIndex("dbo.Invitation", "InvitationEmailIndex");
            DropIndex("dbo.Invitation", new[] { "AccountID" });
            DropIndex("dbo.EmailVerification", new[] { "CreatedByAccountID" });
            DropIndex("dbo.EmailVerification", "EmailVerificationTokenIndex");
            DropIndex("dbo.EmailVerification", "EmailVerificationEmailIndex");
            DropIndex("dbo.EmailVerification", new[] { "AccountID" });
            DropTable("dbo.Invitation");
            DropTable("dbo.EmailVerification");
        }
    }
}
