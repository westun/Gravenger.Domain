namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueIndexOnPostcardTableForAccountIDAndCardID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Postcard", new[] { "AccountID" });
            DropIndex("dbo.Postcard", new[] { "CardID" });
            CreateIndex("dbo.Postcard", new[] { "AccountID", "CardID" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Postcard", new[] { "AccountID", "CardID" });
            CreateIndex("dbo.Postcard", "CardID");
            CreateIndex("dbo.Postcard", "AccountID");
        }
    }
}
