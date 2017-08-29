using StationsExam.Data.Configurations;

namespace StationsExam.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StationsExam.Models;

    public class StationContext : DbContext
    {

        public StationContext()
            : base("name=StationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<StationContext>());
        }



        public virtual DbSet<Train> Trains { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<SeatingClass> SeatingClasses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TrainSeat> TrainSeats { get; set; }
        public virtual DbSet<CustomerCard> CustomerCards { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    modelBuilder.Configurations.Add(new CustomerCardConfiguration());
        //    modelBuilder.Configurations.Add(new SeatingClassConfiguration());
        //    modelBuilder.Configurations.Add(new StationConfiguration());

        //    modelBuilder.Configurations.Add(new TicketConfiguration());
        //    modelBuilder.Configurations.Add(new TrainConfiguration());
        //    modelBuilder.Configurations.Add(new TrainSeatConfiguration());
        //    modelBuilder.Configurations.Add(new TripConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
    


}