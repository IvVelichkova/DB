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
	public	class InviteToTeamCommand
	{
		public string Execute (string[] inputArgs)
		{
//	InviteToTeam <teamName> <username>

			Check.CheckLength(2,inputArgs);
			AuthenticationManager.Authorize();

			string teamName = inputArgs[0];
			string username = inputArgs[1];

			if (!CommandHelper.IsUserExisting(username) || !CommandHelper.IsTeamExisting(teamName))
			{
				throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
			}


			if (this.IsInvitePending(teamName,username))
			{
				throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
			}

			if (!this.IsCreatorOrPartOfTeam(teamName))
			{
				throw  new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
			}

			this.SentInvite(teamName, username);

			return $"Team {teamName} invited {username}!";
		}


		private void SentInvite(string teamName, string username)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
				User user = context.Users.FirstOrDefault(u => u.Username == username);

				Invintation invintation = new Invintation()
				{
					InvitedUser = user,
					Team = team
				};

				

				if (team.CreatorId == user.Id)
				{
					team.Members.Add(user);
					invintation.IsActive = false;
				}

				context.Invintations.Add(invintation);
				context.SaveChanges();
			}
		}


		

		private bool IsCreatorOrPartOfTeam(string teamName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User currentUser = AuthenticationManager.GetCurrentUser();

				return
					context.Teams.Include("Members")
						.Any(t => t.Name == teamName && 
						(t.CreatorId == currentUser.Id ||
						t.Members.Any(m => m.Username == currentUser.Username)));
			}
		}



		private bool IsInvitePending(string teamName, string username)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return
					context.Invintations.Include("Team")
						.Include("InvitedUser")
						.Any(t => t.Team.Name == teamName && t.InvitedUser.Username == username && t.IsActive);
			}
		}
	}
}
