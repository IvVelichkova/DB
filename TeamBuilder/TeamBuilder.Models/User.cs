using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
   public enum Gender
    {
        Male,
        Female
    }
    public class User
    {
        public User()
        {
            this.CreatedEvents = new HashSet<Event>();
            this.CreatedTeams = new HashSet<Team>();
            this.ReceivedInvitations = new HashSet<Invitation>();
            this.Teams = new HashSet<Team>();
        }
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(25)]
        public string Username { get; set; }
        [MaxLength(25)]
        public string FristName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        [MinLength(6),MaxLength(30)]
        public string Password { get; set; }

        public Gender Gender { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Event> CreatedEvents { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Team> CreatedTeams { get; set; }
        public virtual ICollection<Invitation> ReceivedInvitations { get; set; }



    }
}
