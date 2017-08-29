using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<User>();
            this.ParticipatingEvens = new HashSet<Event>();
            this.ReceivedInvintations = new HashSet<Invitation>();
        }
        public int Id { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string Description { get; set; }
        [Required,MinLength(3),MaxLength(3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<Event> ParticipatingEvens { get; set; }
        public  virtual ICollection<Invitation> ReceivedInvintations { get; set; }
    }
}
