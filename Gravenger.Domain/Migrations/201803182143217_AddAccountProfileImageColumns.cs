namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountProfileImageColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "ProfileImageFileName", c => c.String());
            AddColumn("dbo.Account", "ProfileImageFullPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "ProfileImageFullPath");
            DropColumn("dbo.Account", "ProfileImageFileName");
        }
    }
}
