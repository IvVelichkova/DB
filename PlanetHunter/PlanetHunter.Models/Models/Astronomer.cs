namespace PlanetHunter.Models.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
		public enum Role
		{
			Pioneer,
			Observers
		}

	public class Astronomer
	{
		public Astronomer()
		{
			this.Discoveries = new HashSet<Discovery>();
			this.Observations = new HashSet<Discovery>();
		}
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public Role? Role { get; set; }
		public virtual ICollection<Discovery> Discoveries { get; set; }
		public virtual ICollection<Discovery> Observations { get; set; }

	}
}
