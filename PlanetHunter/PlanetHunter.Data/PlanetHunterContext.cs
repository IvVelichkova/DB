using PlanetHunter.Data.Configurations;
using PlanetHunter.Models.Models;

namespace PlanetHunter.Data
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class PlanetHunterContext : DbContext
	{
		public PlanetHunterContext()
			: base("name=PlanetHunterContext")
		{
			Database.SetInitializer( new DropCreateDatabaseAlways<PlanetHunterContext>());
		}

		
		 public virtual DbSet<Astronomer> Astronomers { get; set; }
		public virtual DbSet<Planet> Planets { get; set; }

		public virtual DbSet<Star> Stars { get; set; }
		public virtual DbSet<StarSystem> StarSystems { get; set; }

		public virtual DbSet<Telescope> Telescopes { get; set; }

		public virtual  DbSet<Discovery> Discoveries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new AstronomerConfiguration());
			modelBuilder.Configurations.Add(new PlanetConfiguration());
			modelBuilder.Configurations.Add(new StarConfiguration());
			modelBuilder.Configurations.Add(new DiscoveryConfiguration());
			modelBuilder.Configurations.Add(new StarSystemConfiguration());
			modelBuilder.Configurations.Add(new TelescopeConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}