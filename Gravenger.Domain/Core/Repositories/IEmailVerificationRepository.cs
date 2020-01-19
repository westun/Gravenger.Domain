using Gravenger.Domain.Core.Models;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IEmailVerificationRepository : IRepository<EmailVerification>
    {
        EmailVerification GetByIDAndToken(int emailVerificationID, string token);
    }
}
