using Gravenger.Domain.Core.Models.Reports;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<TopActiveCard> GetTopActiveCards();
        IEnumerable<TopLikedUser> GetTopLikedUsers();
        IEnumerable<TopLikedUser> GetTopLikedFollowers(int accountID);
        IEnumerable<TopLikedUser> GetTopLikedFollowees(int accountID);
        IEnumerable<TopLikedCard> GetTopLikedCards();
    }
}
