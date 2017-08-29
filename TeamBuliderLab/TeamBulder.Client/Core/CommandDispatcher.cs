
using System;
using System.Linq;
using TeamBulder.Client.Core.Commands;

namespace TeamBulder.Client.Core
{
	public class CommandDispatcher
	{
		public string Dispatch(string input)
		{
			string result = string.Empty;

			string[] inputArgs = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

			string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;

			inputArgs = inputArgs.Skip(1).ToArray();

			switch (commandName)
			{

				case "RegisterUser":
					RegisterUserCommand registerUser = new RegisterUserCommand();
					result = registerUser.Execute(inputArgs);
					break;

				case "Login":
					LoginCommand login = new LoginCommand();
					result = login.Execute(inputArgs);
					break;

				case "Logout":
					LogoutCommand logout = new LogoutCommand();
					result = logout.Execute(inputArgs);
					break;

				case "DeleteUser":
					DeleteCommand delete = new DeleteCommand();
					result = delete.Execute(inputArgs);
					break;

				case "CreateEvent":
					CreateEventCommand createEvent = new CreateEventCommand();
					result = createEvent.Execute(inputArgs);
					break;

				case "CreateTeam":
					CreateTeamCommand createTeam = new CreateTeamCommand();
					result = createTeam.Execute(inputArgs);
					break;

				case "InviteToTeam":
					InviteToTeamCommand inviteToTeam = new InviteToTeamCommand();
					result = inviteToTeam.Execute(inputArgs);
					break;

				case "AcceptInvite":
					AcceptInviteCommand acceptInvite = new AcceptInviteCommand();
					result = acceptInvite.Execute(inputArgs);
					break;

				case "DeclineInvite":
					DeclineInviteCommand declineInvite = new DeclineInviteCommand();
					result = declineInvite.Execute(inputArgs);
					break;

				case "KickMember":
					KickMemberCommand kickMember = new KickMemberCommand();
					result = kickMember.Execute(inputArgs);
					break;

				case "Disband":
					DisbandTeamCommand disbandTeam = new DisbandTeamCommand();
					result = disbandTeam.Execute(inputArgs);
					break;

				case "AddTeamTo":
					AddTeamToCommand addTeamTo = new AddTeamToCommand();
					result = addTeamTo.Execute(inputArgs);
					break;

				case "Exit":
					ExitCommand exit = new ExitCommand();
					exit.Execute(inputArgs);
					break;

				

				default:
					throw new NotSupportedException($"Command {commandName} not supported!");

			
			}

			return result;
		}

		
	}
}
