using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationsExam.Models
{
    /*Name – text with max length 30 (required, unique)
       Abbreviation – text with length 2 (required) */
    public class SeatingClass
    {
        public SeatingClass()
        {
            this.TrainSeats = new HashSet<TrainSeat>();
        }
        public int Id { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,MaxLength(2),MinLength(2)]
        public string Abbreviation { get; set; }

       
        public Train Train { get; set; }
        public virtual ICollection<TrainSeat> TrainSeats { get; set; }


    }
}
