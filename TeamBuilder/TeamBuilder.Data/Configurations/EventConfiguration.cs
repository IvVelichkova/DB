using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using TeamBuilder.Models;


namespace TeamBuilder.Data.Configurations
{
   public class EventConfiguration: EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            this.Property(u => u.Name).IsRequired().HasMaxLength(25);
            this.Property(u => u.Description).HasMaxLength(250);
            this.HasRequired(e => e.Creator).WithMany(u => u.CreatedEvents);
            this.HasMany(a => a.ParticipatingTeams).WithMany(e => e.ParticipatingEvens).Map(
                ca =>
                {
                    ca.MapLeftKey("EventId");
                    ca.MapRightKey("TeamId");
                    ca.ToTable("EventTeam");
                });


        }
    }
}
