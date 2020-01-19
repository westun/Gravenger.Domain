using Gravenger.Domain.Core.Repositories;
using System;

namespace Gravenger.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IAccountNotificationRepository AccountNotifications { get; }
        IAccountTileRepository AccountTiles { get; }
        IAccountTileLikeRepository AccountTileLikes { get; }
        ICardRepository Cards { get; }
        ICategoryRepository Categories { get; }
        IEmailVerificationRepository EmailVerifications { get; }
        IFollowingRepository Followings { get; }
        IInvitationRepository Invitations { get; }
        IPasswordResetRequestRepository PasswordResetRequests { get; }
        IPostcardLikeRepository PostcardLikes { get; }
        IPostcardRepository Postcards { get; }
        IReportRepository Reports { get; }
        IRoleRepository Roles { get; }
        ITagRepository Tags { get; }
        ITileRepository Tiles { get; }
        int Complete();
    }
}
