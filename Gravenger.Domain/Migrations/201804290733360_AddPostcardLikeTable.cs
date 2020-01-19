namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostcardLikeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostcardLike",
                c => new
                    {
                        PostcardLikeID = c.Int(nullable: false, identity: true),
                        PostcardID = c.Int(nullable: false),
                        AccountID = c.Int(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7, defaultValueSql: "GETUTCDATE()"),
                    })
                .PrimaryKey(t => t.PostcardLikeID)
                .ForeignKey("dbo.Account", t => t.AccountID)
                .ForeignKey("dbo.Postcard", t => t.PostcardID)
                .Index(t => t.PostcardID)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostcardLike", "PostcardID", "dbo.Postcard");
            DropForeignKey("dbo.PostcardLike", "AccountID", "dbo.Account");
            DropIndex("dbo.PostcardLike", new[] { "AccountID" });
            DropIndex("dbo.PostcardLike", new[] { "PostcardID" });
            DropTable("dbo.PostcardLike");
        }
    }
}
