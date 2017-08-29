using System.ComponentModel.DataAnnotations;

namespace PlanetHunter.Models.Models
{
	public class Planet
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[Range(0,float.MaxValue)]
		public float Mass { get; set; }

		public StarSystem HostStarSystem { get; set; }
	}
}
