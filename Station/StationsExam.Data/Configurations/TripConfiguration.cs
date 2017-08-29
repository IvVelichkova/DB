using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationsExam.Models;

namespace StationsExam.Data.Configurations
{
    class TripConfiguration: EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            /*/*Origin Station – station from which the trip starts (required)
Destination Station –  station from which where the trip ends (required)
Departure Time – date and time of departing from origin station (required)
Arrival Time – date and time of arriving at destination station, must be after departure time (required)
Train – train used for that particular trip (required)
Status – values be: "OnTime", "Delayed" and "Early" (default value: "OnTime")
ime Difference – time(span) representing how much given train was late or early. */
            HasKey(p => p.Id);
            this.HasRequired(a => a.Train).WithMany(a => a.Trips).WillCascadeOnDelete(false);
            this.HasRequired(a => a.OriginStation);

            ;
            this.HasRequired(a => a.OriginStation);
            this.HasRequired(a => a.DestinationStation);
            
        }
    }
}
