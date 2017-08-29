using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	class LogoutCommand
	{
		public string Execute(string[] inputArgs)
		{
			Check.CheckLength(0,inputArgs);
			AuthenticationManager.Authorize();
			User curreUser = AuthenticationManager.GetCurrentUser();

			AuthenticationManager.Logout();

			return $"User {curreUser.Username} Successfully logged out!";
		}
	}
}
