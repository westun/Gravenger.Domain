using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IPostcardLikeRepository : IRepository<PostcardLike>
    {
        PostcardLike Get(int accountID, int postcardID);
        IEnumerable<PostcardLike> GetAllByPostcardID(int postcardID);
        void Add(int accountID, int postcardID);
    }
}