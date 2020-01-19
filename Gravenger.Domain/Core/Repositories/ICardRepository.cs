using System.Collections.Generic;
using Gravenger.Domain.Core.Models;

namespace Gravenger.Domain.Core.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetWithTilesTagsCategories(int cardID);
        Card GetWithTilesAndPostcards(int cardID, int accountID);
        IEnumerable<Card> GetAllWithCategories();
        IEnumerable<Card> GetAllWithCategoriesAndTiles();
        IEnumerable<Card> GetAllWithCategoriesAndTiles(int accountID);
        IEnumerable<Card> Search(string searchCriteria);
        IEnumerable<Card> SearchWithCategoriesAndTiles(int accountID, string searchCriteria);
    }
}
