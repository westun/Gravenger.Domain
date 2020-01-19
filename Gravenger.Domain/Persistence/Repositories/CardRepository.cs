using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(GravengerContext context)
            : base(context)
        {
        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public Card GetWithTilesTagsCategories(int cardID)
        {
            return this.Context.Cards
                .Where(c => c.CardID == cardID)
                .Include(c => c.Category)
                .Include(c => c.Tiles)
                .Include(c => c.Tags)
                .FirstOrDefault();
        }

        public Card GetWithTilesAndPostcards(int cardID, int accountID)
        {
            var card = this.Context.Cards
               .Include(c => c.Tiles)
               .FirstOrDefault(c => c.CardID == cardID);

            this.Context.Postcards
                .Where(pc => pc.CardID == cardID && pc.AccountID == accountID)
                .Include(pc => pc.AccountTiles)
                .Include(pc => pc.PostcardLikes)
                .Load();

            return card;
        }

        public IEnumerable<Card> GetAllWithCategories()
        {
            return this.Context.Cards
                .Include(c => c.Category)
                .OrderBy(c => c.Title)
                .ToList();
        }

        public IEnumerable<Card> GetAllWithCategoriesAndTiles()
        {
            return this.Context.Cards
                .Include(c => c.Category)
                .Include(c => c.Tiles)
                .OrderBy(c => c.Title)
                .ToList();
        }
        
        public IEnumerable<Card> GetAllWithCategoriesAndTiles(int accountID)
        {
            //TODO: Should this db call not include postcards?  Rather in the card page scenario make a separate 
            //      database call to get postcards for a specific card that is viewed?
            //      what about list of cards in admin that may want to display statistics of users and likes?
            //      maybe card page should use separate db calls for card search/list of cards
            //      versus when a card is clicked to view?  That way when viewing card db call is much smaller
            //      and targets specific account id.
            
            var cards = this.Context.Cards
                .Include(c => c.Category)
                .Include(c => c.Tiles)
                .Include(c => c.Postcards) //this only pulls ALL Postcards to display number of users subscribed to card when a user is viewing a card
                .OrderBy(c => c.Title)
                .ToList();

            //Explicit loading
            this.Context.AccountTiles
                .Where(at => at.AccountID == accountID)
                .Load();
            
            //Explicit loading
            //This will only return the postcard likes for the given accountID, oppose to all postcard likes for all postcards
            //Currently this method only pulls postcard like information to display the number of likes
            //when the user is viewing any given card.  This could be a separate api/database call all instead.
            this.Context.Postcards
                .Where(pc => pc.AccountID == accountID)
                .Select(pc => pc.PostcardLikes)
                .Load();

            return cards;
        }

        public IEnumerable<Card> Search(string searchCriteria)
        {
            return this.Context.Cards
                .Where(c => c.Title.Contains(searchCriteria))
                .Include(c => c.Category)
                .OrderBy(c => c.Title)
                .ToList();
        }

        public IEnumerable<Card> SearchWithCategoriesAndTiles(int accountID, string searchCriteria)
        {
            //TODO: Should this db call not include postcards?  Rather in the card page scenario make a separate 
            //      database call to get postcards for a specific card that is viewed?
            //      what about list of cards in admin that may want to display statistics of users and likes?
            //      maybe card page should use separate db calls for card search/list of cards
            //      versus when a card is clicked to view?  That way when viewing card db call is much smaller
            //      and targets specific account id.

            var cards = this.Context.Cards
                .Where(c => c.Title.Contains(searchCriteria))
                .Include(c => c.Category)
                .Include(c => c.Tiles)
                .Include(c => c.Postcards) //this only pulls ALL Postcards to display number of users subscribed to card when a user is viewing a card
                .OrderBy(c => c.Title)
                .ToList();

            //Explicit loading
            this.Context.AccountTiles
                .Where(at => at.AccountID == accountID)
                .Load();

            //Explicit loading
            //This will only return the postcard likes for the given accountID, oppose to all postcard likes for all postcards
            //Currently this method only pulls postcard like information to display the number of likes
            //when the user is viewing any given card.  This could be a separate api/database call all instead.
            this.Context.Postcards
                .Where(pc => pc.AccountID == accountID)
                .Select(pc => pc.PostcardLikes)
                .Load();

            return cards;
        }
    }
}
