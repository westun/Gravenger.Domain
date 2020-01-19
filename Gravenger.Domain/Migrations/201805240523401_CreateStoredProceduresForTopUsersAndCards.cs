namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateStoredProceduresForTopUsersAndCards : DbMigration
    {
        public override void Up()
        {
            this.CreateStoredProcedure("GetTopFiveLikedUsers",
                body: @"
                    SELECT 
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

            this.CreateStoredProcedure("GetTopFiveActiveCards",
                body: @"
                    SELECT TOP 5
	                    Card.CardID, 
	                    Card.Title, 
	                    COUNT(Postcard.PostcardID) AS [TotalUsers]
                    FROM Card
	                    LEFT OUTER JOIN Postcard
	                    ON Postcard.CardID = Card.CardID
                    GROUP BY Card.CardID, Card.Title
                    ORDER BY [TotalUsers] DESC"
            );

            this.CreateStoredProcedure("GetTopFiveLikedFollowers",
                p => new { AccountID = p.Int() },
                body: @"
                    SELECT TOP 5
		                Account.AccountID, 
		                Account.Username, 
		                Account.ProfileImageFullPath,
		                COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Following
    	                LEFT OUTER JOIN Account
    	                ON Account.AccountID = Following.FollowerID
    	                LEFT OUTER JOIN Postcard
    	                ON Account.AccountID = Postcard.AccountID 
    	                LEFT OUTER JOIN PostcardLike
    	                ON PostcardLike.PostcardID = Postcard.PostcardID
                    WHERE Following.FolloweeID = @AccountID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );

            this.CreateStoredProcedure("GetTopFiveLikedFollowees",
                p => new { AccountID = p.Int() },
                body: @"
                    SELECT TOP 5
		                Account.AccountID, 
		                Account.Username, 
		                Account.ProfileImageFullPath,
		                COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Following
    	                LEFT OUTER JOIN Account
    	                ON Account.AccountID = Following.FolloweeID
    	                LEFT OUTER JOIN Postcard
    	                ON Account.AccountID = Postcard.AccountID 
    	                LEFT OUTER JOIN PostcardLike
    	                ON PostcardLike.PostcardID = Postcard.PostcardID
                    WHERE Following.FollowerID = @AccountID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );
        }

        public override void Down()
        {
            this.DropStoredProcedure("GetTopFiveLikedUsers");
            this.DropStoredProcedure("GetTopFiveActiveCards");
            this.DropStoredProcedure("GetTopFiveLikedFollowers");
            this.DropStoredProcedure("GetTopFiveLikedFollowees");
        }
    }
}
