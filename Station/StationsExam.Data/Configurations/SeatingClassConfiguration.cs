using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationsExam.Models;

namespace StationsExam.Data.Configurations
{
    class SeatingClassConfiguration:EntityTypeConfiguration<SeatingClass>
    {
        public SeatingClassConfiguration()
        {
            Property(p => p.Name).IsRequired();
            this.HasRequired(p => p.Train).WithMany(a => a.SeatClasses).WillCascadeOnDelete(false);
            //this.HasRequired(ts => ts.Train).WithMany(t => t.TrainSeats).WillCascadeOnDelete(false);
        }

    }
}
