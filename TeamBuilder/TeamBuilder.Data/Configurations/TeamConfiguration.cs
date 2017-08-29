using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(n => n.Name).HasMaxLength(25);
            this.Property(u => u.Name)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_Teams_TeamsName", 1)
                        {
                            IsUnique = true
                        }));
            this.Property(n => n.Description).HasMaxLength(32);
            this.Property(n => n.Acronym).IsRequired();
            

        }
    }
}
