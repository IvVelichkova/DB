
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core
{
	public class AuthenticationManager
	{
		private static User currentUser;


		public static void Login(string username ,string password )
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

				if (currentUser != null)
				{
					throw new ArgumentException("You should logout first!");
				}

				if (user == null)
				{
					throw new ArgumentException("Invalid username or password!");
				}

				currentUser = user;
			}
			
		}

		public static void Login(User user)
		{
			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				// user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
				if (currentUser != null)
				{
					throw new ArgumentException("You should logout first!");
				}

				if (user == null)
				{
					throw new ArgumentException("Invalid username or password!");
				}

				currentUser = user;
			}
		}

		public static void Logout()
		{
			if (currentUser == null)
			{
				throw new InvalidOperationException("You should log in first in order to logout.");
			}

			currentUser = null;
		}

		public static User GetCurrentUser()
		{
			return currentUser;
		}

		public static bool IsAuthenticated()
		{
			return currentUser != null;
		}

		public static void Authorize()
		{
			if (currentUser == null)
			{
				throw  new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
			}
		}


	}
	
}
