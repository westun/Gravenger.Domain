namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountRoleManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Role", "Account_AccountID", "dbo.Account");
            DropIndex("dbo.Role", new[] { "Account_AccountID" });
            CreateTable(
                "dbo.RoleAccount",
                c => new
                    {
                        Role_RoleID = c.Int(nullable: false),
                        Account_AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleID, t.Account_AccountID })
                .ForeignKey("dbo.Role", t => t.Role_RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Account_AccountID, cascadeDelete: true)
                .Index(t => t.Role_RoleID)
                .Index(t => t.Account_AccountID);
            
            DropColumn("dbo.Role", "Account_AccountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "Account_AccountID", c => c.Int());
            DropForeignKey("dbo.RoleAccount", "Account_AccountID", "dbo.Account");
            DropForeignKey("dbo.RoleAccount", "Role_RoleID", "dbo.Role");
            DropIndex("dbo.RoleAccount", new[] { "Account_AccountID" });
            DropIndex("dbo.RoleAccount", new[] { "Role_RoleID" });
            DropTable("dbo.RoleAccount");
            CreateIndex("dbo.Role", "Account_AccountID");
            AddForeignKey("dbo.Role", "Account_AccountID", "dbo.Account", "AccountID");
        }
    }
}
