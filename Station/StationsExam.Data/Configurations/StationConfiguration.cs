using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationsExam.Models;

namespace StationsExam.Data.Configurations
{
    class StationConfiguration: EntityTypeConfiguration<Station>
    
    {
        public StationConfiguration()
        {
            /*Name – text with max length 50 (required, unique – non-primary key)
Town – text with max length 50 */
            HasKey(p => p.Id);
            Property(n=>n.Name).HasMaxLength(50).IsRequired().HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_NameStation", 1) { IsUnique = true }));
            this.Property(t => t.Town).HasMaxLength(50);
            

        }
    }
}
