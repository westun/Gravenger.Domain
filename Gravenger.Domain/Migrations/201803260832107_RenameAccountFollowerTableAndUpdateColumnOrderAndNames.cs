namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAccountFollowerTableAndUpdateColumnOrderAndNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountFollower", newName: "AccountFollowing");
            RenameColumn(table: "dbo.AccountFollowing", name: "AccountID", newName: "AccountFollowerID");
            RenameColumn(table: "dbo.AccountFollowing", name: "FollowerID", newName: "AccountFolloweeID");
            RenameIndex(table: "dbo.AccountFollowing", name: "IX_AccountID", newName: "IX_AccountFollowerID");
            RenameIndex(table: "dbo.AccountFollowing", name: "IX_FollowerID", newName: "IX_AccountFolloweeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AccountFollowing", name: "IX_AccountFolloweeID", newName: "IX_FollowerID");
            RenameIndex(table: "dbo.AccountFollowing", name: "IX_AccountFollowerID", newName: "IX_AccountID");
            RenameColumn(table: "dbo.AccountFollowing", name: "AccountFolloweeID", newName: "FollowerID");
            RenameColumn(table: "dbo.AccountFollowing", name: "AccountFollowerID", newName: "AccountID");
            RenameTable(name: "dbo.AccountFollowing", newName: "AccountFollower");
        }
    }
}
