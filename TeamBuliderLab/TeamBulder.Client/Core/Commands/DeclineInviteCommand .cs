﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
//	•	DeclineInvite<teamName>
 public 	class DeclineInviteCommand
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

			if (!CommandHelper.IsInviteExisting(teamName, AuthenticationManager.GetCurrentUser()))
			{
				throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
			}

			this.DeclineInvite(teamName);
			return $"Invite from {teamName} declined.";
		}
		private void DeclineInvite(string teamName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User currentUser = AuthenticationManager.GetCurrentUser();
				Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

				currentUser = context.Users.FirstOrDefault(u => u.Username == currentUser.Username);

				//currentUser.Teams.Add(team);
				Invintation invintation =
					context.Invintations.FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == currentUser.Id && i.IsActive);
				if (invintation.IsActive)
				{

				invintation.IsActive = false;
					
				}
				


				context.SaveChanges();
			}
		}
	}
}
