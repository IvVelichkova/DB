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
	public class AddTeamToCommand
	{
		public string Execute(string[] inputArgs)
		{
			Check.CheckLength(2, inputArgs);
			AuthenticationManager.Authorize();

			string eventName = inputArgs[0];

			if (!CommandHelper.IsEventExisting(eventName))
			{
				throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound,eventName));
			}

			string teamName = inputArgs[1];

			if (!CommandHelper.IsTeamExisting(teamName))
			{
				throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
			}


			User currentUser = AuthenticationManager.GetCurrentUser();

			if (!CommandHelper.IsUserCreatorOfEvent(eventName, currentUser))
			{
				throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
			}

			this.AddTeamToEvent(teamName, eventName);
			return $"Team {teamName} added for {eventName}!";
		}

		private void AddTeamToEvent(string teamName, string eventName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);

				Event ev = context.Events.OrderByDescending(e => e.StartDate).FirstOrDefault(e => e.Name == eventName);
				if (ev.ParticipatingTeam.Any(t=>t.Name==teamName))
				{
					throw new InvalidOperationException(Constants.ErrorMessages.CannotAddSameTeamTwice);
				}
				ev.ParticipatingTeam.Add(team);
				context.SaveChanges();

			}
		}
	}
}
