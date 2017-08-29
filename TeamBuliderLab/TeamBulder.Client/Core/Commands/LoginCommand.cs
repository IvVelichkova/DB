using System;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	public class LoginCommand
	{
		public string Execute(string[] inputArgs)
		{
			Check.CheckLength(2, inputArgs);
			string username = inputArgs[0];
			string password = inputArgs[1];

			if (AuthenticationManager.IsAuthenticated())
			{
				throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
			}

			User user = this.GetUserByCredentials(username, password);

			if (user == null )
			{
				throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
			}

			AuthenticationManager.Login(user);

			return $"User {user.Username} successfully logged in ! ";
		}

		private static User currentUser = new User();
		private  User GetUserByCredentials(string username, string password)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User user =
					context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsDeleted == false);

			 currentUser = user;
			}

			return currentUser;
			
		}
	}
}