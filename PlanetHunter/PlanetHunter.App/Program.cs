using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunter.Data;

namespace PlanetHunter.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var context = new PlanetHunterContext();

			context.Database.Initialize(true);
		}
	}
}
