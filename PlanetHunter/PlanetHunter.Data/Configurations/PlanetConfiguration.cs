using System.Data.Entity.ModelConfiguration;
using PlanetHunter.Models.Models;

namespace PlanetHunter.Data.Configurations
{
	class PlanetConfiguration:EntityTypeConfiguration<Planet>
	{
		public PlanetConfiguration()
		{
			this.Property(n => n.Name).IsRequired().HasMaxLength(255);
			
			this.HasRequired(s => s.HostStarSystem);
		}
	}
}
