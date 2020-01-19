using Gravenger.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Gravenger.Domain.Persistence.EntityConfigurations
{
    public class PasswordResetRequestConfiguration : EntityTypeConfiguration<PasswordResetRequest>
    {
        public PasswordResetRequestConfiguration()
        {
            this.HasKey(p => p.PasswordResetRequestID);
            
            this.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.CreatedDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
                        
            this.HasIndex(e => e.Token);
       }
    }
}