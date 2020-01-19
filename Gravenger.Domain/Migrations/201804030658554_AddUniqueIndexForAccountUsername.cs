namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueIndexForAccountUsername : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Account", "Username", unique: true, name: "AccountUsernameIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Account", "AccountUsernameIndex");
        }
    }
}
