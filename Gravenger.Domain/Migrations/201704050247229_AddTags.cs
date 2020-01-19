namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.TagCard",
                c => new
                    {
                        Tag_TagID = c.Int(nullable: false),
                        Card_CardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagID, t.Card_CardID })
                .ForeignKey("dbo.Tag", t => t.Tag_TagID, cascadeDelete: true)
                .ForeignKey("dbo.Card", t => t.Card_CardID, cascadeDelete: true)
                .Index(t => t.Tag_TagID)
                .Index(t => t.Card_CardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagCard", "Card_CardID", "dbo.Card");
            DropForeignKey("dbo.TagCard", "Tag_TagID", "dbo.Tag");
            DropIndex("dbo.TagCard", new[] { "Card_CardID" });
            DropIndex("dbo.TagCard", new[] { "Tag_TagID" });
            DropTable("dbo.TagCard");
            DropTable("dbo.Tag");
        }
    }
}
