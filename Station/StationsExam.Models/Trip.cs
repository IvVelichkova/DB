using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationsExam.Models
{
    public enum Status
    {
        OnTime,
        Delayed,
        Early
    }
    public class Trip

    /*Origin Station – station from which the trip starts (required)
Destination Station –  station from which where the trip ends (required)
Departure Time – date and time of departing from origin station (required)
Arrival Time – date and time of arriving at destination station, must be after departure time (required)
Train – train used for that particular trip (required)
Status – values be: "OnTime", "Delayed" and "Early" (default value: "OnTime")
ime Difference – time(span) representing how much given train was late or early. */
    {
        [Key]
        public int Id { get; set; }
        public int OriginStationId { get; set; }
        

        public  Station OriginStation { get; set; }

        public int DestinationStationId { get; set; }
        
        public  Station DestinationStation { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public Train Train { get; set; }
        public Status Status { get; set; }

        public TimeSpan DifferenceTime { get; set; }


    }

}
