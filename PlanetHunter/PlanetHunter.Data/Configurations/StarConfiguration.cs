using System.Data.Entity.ModelConfiguration;
using PlanetHunter.Models.Models;

namespace PlanetHunter.Data.Configurations
{
	public class StarConfiguration: EntityTypeConfiguration<Star>
	{
		public StarConfiguration()
		{
			this.Property(u => u.Name).IsRequired().HasMaxLength(255);
			this.Property(t => t.Temperature).IsRequired();
		}
	}
}
