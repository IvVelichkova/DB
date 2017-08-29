using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationsExam.Models;

namespace StationsExam.Data.Configurations
{
    /* /*Train – train which seats will be described (required)
    Seating Class – class of the seats (required)
    Quantity – how many seats of given class total for the given train (required, non-negative) */
    class TrainSeatConfiguration : EntityTypeConfiguration<TrainSeat>
    {
        public TrainSeatConfiguration()
        {
            this.HasRequired(ts => ts.Train).WithMany(t => t.TrainSeats).WillCascadeOnDelete(false);
            this.HasRequired(a => a.SeatingClass).WithMany(a => a.TrainSeats).WillCascadeOnDelete(false);
        }
    }
}
