using System.ComponentModel;

namespace TeamBuilder.Data.Configurations
{
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Infrastructure.Annotations;
	using TeamBuilder.Models;
	using System.Data.Entity.ModelConfiguration;

	class EventConfiguration: EntityTypeConfiguration<Event>
	{
	

		public EventConfiguration()
		{
			this.Property(u => u.Name).IsRequired().HasMaxLength(25);

			this.Property(u => u.Description).HasMaxLength(25);

			this.HasRequired(e => e.Creator).WithMany(e => e.CreatEvents);

			this.HasMany(e => e.ParticipatingTeam).WithMany(t => t.ParticipatingEvents).Map(ca =>
			{
				ca.MapLeftKey("EventId");
				ca.MapRightKey("TeamId");
				ca.ToTable("EventTeams");
			});
		}

	}
}
