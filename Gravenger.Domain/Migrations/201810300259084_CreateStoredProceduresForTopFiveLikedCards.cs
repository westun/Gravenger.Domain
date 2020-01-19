namespace Gravenger.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateStoredProceduresForTopFiveLikedCards : DbMigration
    {
        public override void Up()
        {
            this.CreateStoredProcedure("GetTopFiveLikedCards",
                body: @"
                    SELECT TOP 5
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
        }

        public override void Down()
        {
            this.DropStoredProcedure("GetTopFiveLikedCards");
        }
    }
}
