using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Event
    {
        public Event()
        {
            this.ParticipatingTeams = new HashSet<Team>();
            

        }
        public int Id { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(250),]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public virtual ICollection<Team> ParticipatingTeams {get; set;}
      
    }
}
