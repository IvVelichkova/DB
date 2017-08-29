using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
	public class Team
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(25)]
		public string Name { get; set; }
		[MaxLength(32)]
		public string Descrition { get; set; }
		[MinLength(3)]
		[StringLength(3)]
		public string Acronym { get; set; }
		public int CreatorId { get; set; }
		public User Creator { get; set; }

		public virtual  ICollection<User> Members { get; set; }
		public virtual ICollection<Event> ParticipatingEvents{ get; set; }
		public virtual ICollection<Invintation> ReceivedInvintations { get; set; }
	}
}
