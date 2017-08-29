using System.ComponentModel.DataAnnotations;

namespace PlanetHunter.Models.Models
{
	public class Telescope
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
		public string Location { get; set; }
		
		
		[Range(0.0,float.MaxValue)]
		public float? MirrorD { get; set; }

	}
}
