using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }
    }
}
