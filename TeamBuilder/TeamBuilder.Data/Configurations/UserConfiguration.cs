using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBuilder.Data;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;


namespace TeamBuilder.Data.Configurations
{
   public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.Username).IsRequired();
            this.Property(p => p.Password).IsRequired();
            //Now .HasColumnAnnotaion alongside with IndexAttribute should make our Username property unique (quick reference here).
            this.Property(u => u.Username)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_Users_Username", 1)
                        {
                            IsUnique = true
                        }))
                .HasMaxLength(25);
            this.HasMany(u => u.CreatedTeams)
                .WithRequired(t => t.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.CreatedEvents)
                .WithRequired(u => u.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.Teams)
                .WithMany(t => t.Members)
                .Map(ca =>
                    {
                        ca.MapLeftKey("UserId");
                        ca.MapRightKey("TeamId");
                        ca.ToTable("UserTeams");
                    }
                );
            this.HasMany(u => u.ReceivedInvitations)
                .WithRequired(i => i.InvitedUser)
                .WillCascadeOnDelete(false);

        }
    }
}
