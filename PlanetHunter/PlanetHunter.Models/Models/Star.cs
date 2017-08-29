using System.ComponentModel.DataAnnotations;

namespace PlanetHunter.Models.Models
{
	public class Star
	{
		public int Id { get; set; }
		
		public string Name { get; set; }

		[Range(2400,int.MaxValue)]
		public int Temperature { get; set; }

		
		public StarSystem HostStarSystem { get; set; }

	}
}
