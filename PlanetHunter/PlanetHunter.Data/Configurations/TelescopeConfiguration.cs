using System.Data.Entity.ModelConfiguration;
using PlanetHunter.Models.Models;

namespace PlanetHunter.Data.Configurations
{
	public class TelescopeConfiguration:EntityTypeConfiguration<Telescope>
	{
		public TelescopeConfiguration()
		{
			this.Property(n => n.Name).IsRequired().HasMaxLength(255);

			this.Property(l => l.Location).IsRequired().HasMaxLength(255);

			
		}

	}
}
