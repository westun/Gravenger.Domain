namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTopRankingStoredProcedures : DbMigration
    {
        public override void Up()
        {
            this.CreateStoredProcedure("GetTopActiveCards",
                body: @"
                    SELECT
    	                Card.CardID, 
    	                Card.Title, 
    	                COUNT(Postcard.PostcardID) AS [TotalUsers]
                    FROM Card
		                INNER JOIN Postcard
		                ON Postcard.CardID = Card.CardID
                    GROUP BY Card.CardID, Card.Title
                    ORDER BY [TotalUsers] DESC"
            );

            this.CreateStoredProcedure("GetTopLikedCards",
                body: @"
                    SELECT 
		                Card.CardID,
		                Card.Title,
		                COUNT(Card.CardID) AS [TotalLikes]
                    FROM Card
		                INNER JOIN Postcard
		                ON Postcard.CardID = Card.CardID
		                INNER JOIN PostcardLike
		                ON PostcardLike.PostcardID = Postcard.PostcardID
                    GROUP BY Card.CardID, Card.Title
                    ORDER BY [TotalLikes] DESC"
            );

            this.CreateStoredProcedure("GetTopLikedFollowees",
                p => new { AccountID = p.Int() },
                body: @"
                    SELECT
		                Account.AccountID, 
		                Account.Username, 
		                Account.ProfileImageFullPath,
		                COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Following
		                INNER JOIN Account
		                ON Account.AccountID = Following.FolloweeID
		                INNER JOIN Postcard
		                ON Account.AccountID = Postcard.AccountID 
		                INNER JOIN PostcardLike
		                ON PostcardLike.PostcardID = Postcard.PostcardID
                    WHERE Following.FollowerID = @AccountID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );

            this.CreateStoredProcedure("GetTopLikedFollowers",
                p => new { AccountID = p.Int() },
                body: @"
                    SELECT
    	                Account.AccountID, 
    	                Account.Username, 
    	                Account.ProfileImageFullPath,
    	                COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Following
    	                INNER JOIN Account
    	                ON Account.AccountID = Following.FollowerID
    	                INNER JOIN Postcard
    	                ON Account.AccountID = Postcard.AccountID 
    	                INNER JOIN PostcardLike
    	                ON PostcardLike.PostcardID = Postcard.PostcardID
                    WHERE Following.FolloweeID = @AccountID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );

            this.CreateStoredProcedure("GetTopLikedUsers",
                body: @"
                    SELECT
		                Account.AccountID,
		                Account.Username,
		                Account.ProfileImageFullPath,
		                COUNT(PostcardLikeID) AS [TotalLikes]
                    FROM Account
		                INNER JOIN Postcard
		                ON Account.AccountID = Postcard.AccountID
		                INNER JOIN PostcardLike
		                ON PostcardLike.PostcardID = Postcard.PostcardID
                    GROUP BY Account.AccountID, Account.Username, Account.ProfileImageFullPath
                    ORDER BY [TotalLikes] DESC"
            );
        }

        public override void Down()
        {
            this.DropStoredProcedure("GetTopActiveCards");
            this.DropStoredProcedure("GetTopLikedCards");
            this.DropStoredProcedure("GetTopLikedFollowees");
            this.DropStoredProcedure("GetTopLikedFollowers");
            this.DropStoredProcedure("GetTopLikedUsers");
        }
    }
}
