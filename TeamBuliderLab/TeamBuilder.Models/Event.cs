using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
	public class Event
	{
		public Event()
		{
			this.ParticipatingTeam = new List<Team>();
		}

		[Key]
		public int  Id { get; set; }
		[Required]
		[StringLength(25)]
		public string Name { get; set; }
		[StringLength(25)]
		public string Description { get; set; }
//		[DisplayFormat(ApplyFormatInEditMode = true
//			,DataFormatString = "{DD/MM/YYYY HH:mm}")]
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int CreatorId { get; set; }
		public User Creator { get; set; }
		public virtual ICollection<Team>ParticipatingTeam { get; set; }
	}
}
