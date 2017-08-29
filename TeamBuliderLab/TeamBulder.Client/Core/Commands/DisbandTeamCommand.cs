using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	class DisbandTeamCommand
	{
		public string Execute(string[] inputArgs)
		{
			Check.CheckLength(1, inputArgs);
			AuthenticationManager.Authorize();

			string teamName = inputArgs[0];

			if (!CommandHelper.IsTeamExisting(teamName))
			{
				throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
			}

			User currentUser = AuthenticationManager.GetCurrentUser();

			if (!CommandHelper.IsUserCreatorOfTeam(teamName,currentUser))
			{
				throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
			}

			this.DisbandTeam(teamName);

			return $"{teamName} has disbanded!";
		}

		private void DisbandTeam(string teamName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

				context.Teams.Remove(team);
				context.SaveChanges();

			}
		}
	}
}
