namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGetTopFiveLikedUsersStoredProcedureToSelectTop5 : DbMigration
    {
        public override void Up()
        {
            this.AlterStoredProcedure("GetTopFiveLikedUsers",
                body: @"
                    SELECT TOP 5
                        Account.AccountID,
                        Account.Username,
                        Account.ProfileImageFullPath,
                        COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Account
                        LEFT OUTER JOIN Postcard
                        ON Account.AccountID = Postcard.AccountID
                        LEFT OUTER JOIN PostcardLike
                        ON PostcardLike.PostcardID = Postcard.PostcardID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );
        }
        
        public override void Down()
        {
        }
    }
}
