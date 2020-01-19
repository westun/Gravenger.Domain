using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class InvitationConfiguration : EntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration()
        {
            this.HasKey(i => i.InvitationID);

            this.Property(i => i.FirstName)
                .HasMaxLength(80);

            this.Property(i => i.LastName)
                .HasMaxLength(100);

            this.Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(i => i.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            //TODO: turn off cascade delete?
            this.HasOptional(i => i.Account)
                .WithMany(a => a.Invitations)
                .HasForeignKey(i => i.AccountID);
                //.WillCascadeOnDelete(false);

            //TODO: turn off cascade delete?
            this.HasRequired(i => i.CreatedByAccount)
                .WithMany(a => a.CreatedInvitations)
                .HasForeignKey(i => i.CreatedByAccountID);
                //.WillCascadeOnDelete(false);

            this.HasIndex(i => i.Email)
                .IsUnique();
        }
    }
}