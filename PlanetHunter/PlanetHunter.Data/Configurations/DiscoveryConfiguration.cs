
namespace PlanetHunter.Data.Configurations
{
	using System.Data.Entity.ModelConfiguration;
	using Models.Models;
	public class DiscoveryConfiguration : EntityTypeConfiguration<Discovery>
	{

		public DiscoveryConfiguration()
		{
			this.Property(u => u.DateMade).IsRequired();

			this.HasRequired(t => t.TelescopeUsed);

			this.HasMany(s => s.Stars);

			this.HasMany(p => p.Planets);

			this.HasMany(p => p.Pioneers);
			this.HasMany(o => o.Observers);
		}
	}
}
