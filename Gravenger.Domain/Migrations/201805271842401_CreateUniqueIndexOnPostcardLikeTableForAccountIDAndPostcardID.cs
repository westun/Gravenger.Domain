namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUniqueIndexOnPostcardLikeTableForAccountIDAndPostcardID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PostcardLike", new[] { "PostcardID" });
            DropIndex("dbo.PostcardLike", new[] { "AccountID" });
            CreateIndex("dbo.PostcardLike", new[] { "AccountID", "PostcardID" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PostcardLike", new[] { "AccountID", "PostcardID" });
            CreateIndex("dbo.PostcardLike", "AccountID");
            CreateIndex("dbo.PostcardLike", "PostcardID");
        }
    }
}
