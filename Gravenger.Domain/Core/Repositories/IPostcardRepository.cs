using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IPostcardRepository : IRepository<Postcard>
    {
        Postcard Get(int accountID, int cardID);
        Postcard GetWithAccountTiles(int accountID, int cardID);
        Postcard GetWithAccountAndPostcardLikes(int postcardID);
        IEnumerable<Postcard> GetTopLiked(int accountID);
        void Add(int accountID, int cardID);
    }
}