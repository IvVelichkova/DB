using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;
using PlanetHunter.App.Constants;
using PlanetHunter.Data;
using PlanetHunter.Data.DTOs;
using PlanetHunter.Models.Models;

namespace PlanetHunte.ImportJson
{
	class Program
	{
		private const string astronomersPath = "../../../datasets/astronomers.json";

		private const string telescopePath = "../../../datasets/telescopes.json";

		private const string plantesPath = "../../../datasets/planets.json";

		private const string starsPath = "../../../datasets/stars.xml";
		static void Main(string[] args)
		{
			ImportAstronomersJson();
			ImportTelescopsJson();
			ImportPlanetsJson();
			ImportStarsXml();

		}

		private static void ImportStarsXml()
		{
			var xml = XDocument.Load(starsPath);
			var rootElement = xml.Root;
			
			
			var context = new PlanetHunterContext();
			foreach (var starElement in rootElement.Elements())
			{
				string name = starElement.Element("Name").Value;
				int temp = int.Parse(starElement.Element("Temperature").Value);
				string starSys = starElement.Element("StarSystem").Value;

				Star star = new Star()
				{
					Name = name,
					Temperature = temp,
					HostStarSystem = GetStarSystemByName(starSys,context)
				};

				context.Stars.Add(star);

			}
		}


		private static void ImportPlanetsJson()
		{
			var context = new PlanetHunterContext();
			var json = File.ReadAllText(plantesPath);
			var plantes = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);

			foreach (var planet in plantes)
			{
				if (planet.Name == null || planet.Mass == null || planet.Mass < 0 || planet.StarSystem == null )
				{
					Console.WriteLine(Constants.ImportErrorMessage);
					continue;
				}
				var planetEntity = new Planet()
				{
					Name = planet.Name,
					Mass = planet.Mass.Value,
					HostStarSystem = GetStarSystemByName(planet.StarSystem, context),
				};
		

				

				
				context.Planets.Add(planetEntity);
				Console.WriteLine(Constants.ImportNamedEntitySuccessMessage, "Record", planetEntity.Name);
			}
			context.SaveChanges();

		}


		private static void ImportTelescopsJson()
		{
			var context = new PlanetHunterContext();
			var json = File.ReadAllText(telescopePath);
			var telescopes = JsonConvert.DeserializeObject<IEnumerable<TelescopeDto>>(json);

			foreach (var telescope in telescopes)
			{
				if (telescope.Name == null || telescope.Location == null || telescope.MirrorDiameter == null )
				{
					Console.WriteLine(Constants.ImportErrorMessage);
					continue;
				}

				var telescopeEntity = new Telescope()
				{
					Name = telescope.Name,
					Location = telescope.Location,
					MirrorD = telescope.MirrorDiameter
				};
				context.Telescopes.Add(telescopeEntity);
				Console.WriteLine(Constants.ImportNamedEntitySuccessMessage, "Record", telescopeEntity.Name);

			}

			context.SaveChanges();

		}

		private static void ImportAstronomersJson()
		{
			var context = new PlanetHunterContext();
			var json = File.ReadAllText(astronomersPath);
			var astronomers = JsonConvert.DeserializeObject<IEnumerable<AstronomerDto>>(json);

			foreach (var astronomer in astronomers)
			{
				if (astronomer.FirstName == null || astronomer.LastName == null)
				{
					Console.WriteLine(Constants.ImportErrorMessage);
					continue;
				}

				var astronomerEntity = new Astronomer()
				{
					FirstName = astronomer.FirstName,
					LastName = astronomer.LastName
				};

				context.Astronomers.Add(astronomerEntity);
				Console.WriteLine(Constants.ImportNamedEntitySuccessMessage, "Record", astronomerEntity.FirstName + " " + astronomerEntity.LastName);

			}
			context.SaveChanges();
		}
		private static StarSystem GetStarSystemByName(string starSystemName, PlanetHunterContext context)
		{
			if (starSystemName != null  )
			{
				var starSysteEntity = new StarSystem()
				{
					Name = starSystemName
				};
				context.StarSystems.Add(starSysteEntity);
				context.SaveChanges();
			}

			foreach (var starSystem in context.StarSystems)
			{
				

				if (starSystem.Name == starSystemName)
				{
					return starSystem;
				}

				
			}
				 
					
			return null ;
		}
	}
}
