using System.ComponentModel.DataAnnotations;

namespace PlanetHunter.Models.Models
{
	using System;
	using System.Collections.Generic;
	public class Discovery
	{
		public Discovery()
		{
			this.Stars = new HashSet<Star>();
			this.Planets = new HashSet<Planet>();
			this.Pioneers = new HashSet<Astronomer>();
			this.Observers = new HashSet<Astronomer>();

		}
		public int Id { get; set; }
		public DateTime? DateMade { get; set; }

		//[Required]
		public Telescope TelescopeUsed { get; set; }

		public virtual ICollection<Star> Stars { get; set; }

		public virtual ICollection<Planet> Planets { get; set; }
		public virtual ICollection<Astronomer> Pioneers { get; set; }

		public virtual ICollection<Astronomer> Observers { get; set; }

	}
}
