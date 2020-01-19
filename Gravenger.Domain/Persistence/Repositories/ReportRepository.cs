using Gravenger.Domain.Core.Models.Reports;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class ReportRepository: IReportRepository
    {
        private readonly GravengerContext _context;

        public ReportRepository(GravengerContext context)
        {
            this._context = context;
        }
                
        public IEnumerable<TopLikedUser> GetTopLikedUsers()
        {
            return this._context.Database.SqlQuery<TopLikedUser>("GetTopLikedUsers");
        }

        public IEnumerable<TopActiveCard> GetTopActiveCards()
        {
            return this._context.Database.SqlQuery<TopActiveCard>("GetTopActiveCards");
        }

        public IEnumerable<TopLikedUser> GetTopLikedFollowers(int accountID)
        {
            var sqlParamaters = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "AccountID", Value = accountID }
            };

            return this._context.Database.SqlQuery<TopLikedUser>("GetTopLikedFollowers @AccountID", sqlParamaters);
        }

        public IEnumerable<TopLikedUser> GetTopLikedFollowees(int accountID)
        {
            var sqlParamaters = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "AccountID", Value = accountID }
            };

            return this._context.Database.SqlQuery<TopLikedUser>("GetTopLikedFollowees @AccountID", sqlParamaters);
        }

        public IEnumerable<TopLikedCard> GetTopLikedCards()
        {
            return this._context.Database.SqlQuery<TopLikedCard>("GetTopLikedCards");
        }
    }
}
