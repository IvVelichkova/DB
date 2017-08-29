using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationsExam.Models
{
    public class Station
    {
        /*Name – text with max length 50 (required, unique – non-primary key)
Town – text with max length 50 */
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Town { get; set; }

    }
}
