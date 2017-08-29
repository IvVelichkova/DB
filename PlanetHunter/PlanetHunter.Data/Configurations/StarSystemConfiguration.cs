using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunter.Models.Models;

namespace PlanetHunter.Data.Configurations
{
	public class StarSystemConfiguration:EntityTypeConfiguration<StarSystem>
	{
		public StarSystemConfiguration()
		{
			this.Property(n => n.Name).IsRequired().HasMaxLength(255);
			this.HasMany(u => u.Stars);
			this.HasMany(p => p.Planets);
		}

	}
}
