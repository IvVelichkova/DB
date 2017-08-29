using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	// CreateTeam <name> <acronym> <description>
	class CreateTeamCommand
	{
		public string Execute(string[] inputArgs)
		{
			

			if (inputArgs.Length !=2 && inputArgs.Length != 3 )
			{
				throw  new ArgumentOutOfRangeException(nameof(inputArgs));
			}
			AuthenticationManager.Authorize();


			string teamName = inputArgs[0];
			//Validate the Team name length 
			if (teamName.Length < Constants.MinTeamName || teamName.Length > Constants.MaxTeamName)
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InvalidArgumentsCount);
			}

			string acronym = inputArgs[1];
			if (acronym.Length != 3)
			{
				throw  new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym,acronym));
			}


			string descrition = inputArgs.Length == 3 ? inputArgs[2] : null;

			this.AddTeam(teamName, acronym, descrition);
			return $"Team {teamName} successfully created!";
		}

		private void AddTeam(string teamName, string acronym, string descrition)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				Team t = new Team()
				{
					Name = teamName,
					Acronym = acronym,
					Descrition = descrition,
					CreatorId = AuthenticationManager.GetCurrentUser().Id
				};

				context.Teams.AddOrUpdate(t);
				context.SaveChanges();

			}
		}
	}
}
