namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordResetRequestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordResetRequest",
                c => new
                    {
                        PasswordResetRequestID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 100),
                        Used = c.Boolean(nullable: false),
                        Revoked = c.Boolean(nullable: false),
                        Expires = c.DateTimeOffset(nullable: false, precision: 7),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.PasswordResetRequestID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.Token);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordResetRequest", "AccountID", "dbo.Account");
            DropIndex("dbo.PasswordResetRequest", new[] { "Token" });
            DropIndex("dbo.PasswordResetRequest", new[] { "AccountID" });
            DropTable("dbo.PasswordResetRequest");
        }
    }
}
