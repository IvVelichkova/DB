using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationsExam.Models
{
    /*Train – train which seats will be described (required)
    Seating Class – class of the seats (required)
    Quantity – how many seats of given class total for the given train (required, non-negative) */
   public class TrainSeat
    {

       
        public int Id { get; set; }

        public int TrainId { get; set; }
      
        public Train Train { get; set; }

       
        public virtual SeatingClass SeatingClass  { get; set; }

        public int Quantity { get; set; }

    }
}
