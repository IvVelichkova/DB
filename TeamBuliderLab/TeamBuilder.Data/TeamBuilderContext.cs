using TeamBuilder.Data.Configurations;
using TeamBuilder.Models;

namespace TeamBuilder.Data
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class TeamBuilderContext : DbContext
	{
		
		public TeamBuilderContext()
			: base("name=TeamBuilderContext")
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<TeamBuilderContext>());
		}

		
		 public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual  DbSet<Team> Teams { get; set; }
		public virtual DbSet<Invintation>  Invintations{ get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new EventConfiguration());
			modelBuilder.Configurations.Add(new TeamConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}