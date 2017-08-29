


using System.ComponentModel.DataAnnotations;
using StationsExam.Models;
using System;
using System.Collections;


namespace StationsExam.Models
{

    using System;
    using System.Collections.Generic;


    /*Train Number – text with max length 10 (required, unique – non-primary key) 
    Type – values may be: "HighSpeed", "LongDistance" or "Freight" */


    public enum Type
    {
        HighSpeed,
        LongDistance,
        Freight
    }
    public class Train
    {

        public Train()
        {
            this.Trips = new HashSet<Trip>();
            this.TrainSeats = new HashSet<TrainSeat>();
            this.SeatClasses = new HashSet<SeatingClass>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(10)]
        public string TrainNumber { get; set; }

        public Type Type { get; set; }

        //public int TrainSeatsId { get; set; }
        public virtual ICollection<SeatingClass>SeatClasses { get; set; }
   
        public virtual ICollection <TrainSeat>TrainSeats { get; set; }
        public virtual ICollection<Trip> Trips{ get; set; }

    }
}
