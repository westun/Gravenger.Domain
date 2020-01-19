using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class EmailVerificationRepository : Repository<EmailVerification>, IEmailVerificationRepository
    {
        public EmailVerificationRepository(GravengerContext context)
            :base(context)
        {

        }

        private GravengerContext Context
        {
            get { return base.Context as GravengerContext; }
        }

        public EmailVerification GetByIDAndToken(int emailVerificationID, string token)
        {
            return this.Context.EmailVerifications
                .FirstOrDefault(ev => ev.EmailVerificationID == emailVerificationID && ev.Token == token);
        }
    }
}
