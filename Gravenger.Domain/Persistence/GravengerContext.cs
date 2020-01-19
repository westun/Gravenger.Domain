using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Persistence.EntityConfigurations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gravenger.Domain.Persistence
{
    public class GravengerContext : DbContext
    {
        public GravengerContext()
            : base("GravengerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountNotification> AccountNotifications { get; set; }
        public DbSet<AccountTile> AccountTiles { get; set; }
        public DbSet<AccountTileLike> AccountTileLikes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public DbSet<PostcardLike> PostcardLikes { get; set; }
        public DbSet<Postcard> Postcards { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tile> Tiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new AccountCredentialConfiguration());
            modelBuilder.Configurations.Add(new AccountNotificationConfiguration());
            modelBuilder.Configurations.Add(new AccountTileConfiguration());
            modelBuilder.Configurations.Add(new AccountTileLikeConfiguration());
            modelBuilder.Configurations.Add(new CardConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new EmailVerificationConfiguration());
            modelBuilder.Configurations.Add(new FollowingConfiguration());
            modelBuilder.Configurations.Add(new InvitationConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new PasswordResetRequestConfiguration());
            modelBuilder.Configurations.Add(new PostcardConfiguration());
            modelBuilder.Configurations.Add(new PostcardLikeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new TileConfiguration());
        }
    }
}