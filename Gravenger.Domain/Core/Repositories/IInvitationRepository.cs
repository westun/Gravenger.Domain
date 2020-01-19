using Gravenger.Domain.Core.Models;

namespace Gravenger.Domain.Core.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Invitation GetByEmail(string email);
    }
}
