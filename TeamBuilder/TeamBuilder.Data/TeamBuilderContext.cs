
namespace TeamBuilder.Data
{
    using Configurations;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TeamBuilder.Models;


    public class TeamBuilderContext : DbContext
    {

        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<TeamBuilderContext>());
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            modelBuilder.Configurations.Add(new InvitationCofiguration());

            
            base.OnModelCreating(modelBuilder);
        }

    }
    

}