using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace StationsExam.Models
{
    /*Trip – the trip for which the ticket is for (required)
    Price – money value of the ticket (required, non-negative)
    Seating Place – text with max length of 8 which combines seating class abbreviation plus positive integer (required)
    Personal Card – reference to the ticket’s buyer */
    public class Ticket
    {

        public int Id { get; set; }
        [Required]
        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        [Required,MaxLength(8)]
        public string SeatingPlace { get; set; }

        public virtual CustomerCard PersonalCard{ get; set; }
    }
}
