using Gravenger.Domain.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class AccountCredentialConfiguration : EntityTypeConfiguration<AccountCredential>
    {
        public AccountCredentialConfiguration()
        {
            this.HasKey(ac => ac.AccountCredentialID);

            this.Property(ac => ac.Password)
                .IsRequired();

            this.Property(ac => ac.Salt)
                .IsRequired();

            this.Property(ac => ac.Version)
                .IsRequired()
                .HasMaxLength(50);

            this.HasRequired(ac => ac.Account)
                .WithMany(a => a.AccountCredentials);
        }
    }
}