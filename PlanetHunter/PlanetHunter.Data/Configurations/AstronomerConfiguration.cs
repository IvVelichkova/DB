namespace PlanetHunter.Data.Configurations
{
	using Models.Models;
	using System.Data.Entity.ModelConfiguration;
	public class AstronomerConfiguration : EntityTypeConfiguration<Astronomer>
	{
		public AstronomerConfiguration()
		{
			this.Property(f => f.FirstName).IsRequired().HasMaxLength(50);

			this.Property(l => l.LastName).IsRequired().HasMaxLength(50);

			this.HasMany(d => d.Discoveries).WithMany(t => t.Pioneers).Map(ca =>
			{
				ca.MapLeftKey("AstronomerId");
				ca.MapRightKey("DiscoveryId");
				ca.ToTable("Pionner Discoveries");
			});
			this.HasMany(o => o.Observations).WithMany(o => o.Observers).Map(ca =>
			{
				ca.MapLeftKey("AstronomerId");
				ca.MapRightKey("DiscoveryId");
				ca.ToTable("Observed Discoveries");
			});

		}
	}
}
