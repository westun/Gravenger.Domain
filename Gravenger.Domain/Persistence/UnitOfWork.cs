using Gravenger.Domain.Core;
using Gravenger.Domain.Core.Repositories;
using Gravenger.Domain.Persistence.Repositories;

namespace Gravenger.Domain.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GravengerContext _context;
        
        public UnitOfWork(GravengerContext context)
        {
            this._context = context;
            this.Accounts = new AccountRepository(this._context);
            this.AccountNotifications = new AccountNotificationRepository(this._context);
            this.AccountTiles = new AccountTileRepository(this._context);
            this.AccountTileLikes = new AccountTileLikeRepository(this._context);
            this.Cards = new CardRepository(this._context);
            this.Categories = new CategoryRepository(this._context);
            this.EmailVerifications = new EmailVerificationRepository(this._context);
            this.Followings = new FollowingRepository(this._context);
            this.Invitations = new InvitationRepository(this._context);
            this.PasswordResetRequests = new PasswordResetRequestRepository(this._context);
            this.PostcardLikes = new PostcardLikeRepository(this._context);
            this.Postcards = new PostcardRepository(this._context);
            this.Reports = new ReportRepository(this._context);
            this.Roles = new RoleRepository(this._context);
            this.Tags = new TagRepository(this._context);
            this.Tiles = new TileRepository(this._context);
        }

        //TODO: Update UnitOfWork class to lazy load these repository properties
        public IAccountRepository Accounts { get; private set; }
        public IAccountNotificationRepository AccountNotifications { get; private set; }
        public IAccountTileRepository AccountTiles { get; private set; }
        public IAccountTileLikeRepository AccountTileLikes { get; private set; }
        public ICardRepository Cards { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IEmailVerificationRepository EmailVerifications { get; private set; }
        public IInvitationRepository Invitations { get; private set; }
        public IPasswordResetRequestRepository PasswordResetRequests { get; private set; }
        public IPostcardLikeRepository PostcardLikes { get; private set; }
        public IPostcardRepository Postcards { get; private set; }
        public IReportRepository Reports { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ITileRepository Tiles { get; private set; }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._context.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
