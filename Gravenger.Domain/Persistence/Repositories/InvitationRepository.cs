using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public Invitation GetByEmail(string email)
        {
            return this.Context.Invitations.FirstOrDefault(i => i.Email == email);
        }
    }
}
