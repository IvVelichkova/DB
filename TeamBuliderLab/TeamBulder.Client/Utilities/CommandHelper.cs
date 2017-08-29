using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBulder.Client.Utilities
{
	public class CommandHelper
	{
		public static bool IsTeamExisting(string teamName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Teams.Any(t => t.Name == teamName);
			}
		}

		public static bool IsUserExisting(string username)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Users.Any(t => t.Username == username);
			}
		}

		public static bool IsInviteExisting(string teamName, User user)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Invintations.Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
			}
		}

		public static bool IsMemberOfTeam(string teamName, string username)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Teams.Any(t => t.Name == teamName && t.Members.Any(m => m.Username == username));
			}
		}

		public static bool IsEventExisting(string eventName)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Events.Any(t => t.Name == eventName);
			}
		}

		public static bool IsUserCreatorOfEvent(string eventName, User user)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				return context.Events.Any(t => t.Name == eventName && t.Creator == user);
			}
			
		}

		public static bool IsUserCreatorOfTeam(string teamName, User user)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{

				return context.Teams.Any(t => t.Name == teamName && t.Creator.Username == user.Username);
			}
		}

	}
}
