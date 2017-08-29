
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamBuilder.Models
{
using System.ComponentModel.DataAnnotations;

	public enum Gender
	{
		Male,
		Female
	}

	public	class User
	{
		public User()
		{

			this.CreatEvents = new List<Event>();

			this.CreatedTeams = new List<Team>();

			this.Teams = new List<Team>();

			this.ReceivedInvintations = new List<Invintation>();
		}
		
		public int  Id { get; set; }
		

	
		public string Username { get; set; }
		
		
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int  Age { get; set; }
		public Gender Gender { get; set; }
		public bool IsDeleted { get; set; }


		public virtual ICollection<Event> CreatEvents { get; set; }
		public virtual ICollection<Team> Teams { get; set; }
		public virtual ICollection<Team> CreatedTeams { get; set; }
		public virtual ICollection<Invintation> ReceivedInvintations { get; set; }


	}
}
