using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class EmailVerificationConfiguration : EntityTypeConfiguration<EmailVerification>
    {
        public EmailVerificationConfiguration()
        {
            this.HasKey(e => e.EmailVerificationID);
            
            this.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(254);

            this.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            this.HasOptional(e => e.Account)
                .WithMany(a => a.EmailVerifications)
                .HasForeignKey(e => e.AccountID);

            this.HasOptional(e => e.CreatedByAccount)
                .WithMany(a => a.CreatedEmailVerifications)
                .HasForeignKey(e => e.CreatedByAccountID);

            this.HasIndex(e => e.Email);

            this.HasIndex(e => e.Token);
       }
    }
}