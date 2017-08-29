using System;
using System.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
		public 	class DeleteCommand
	{
		public string Execute(string[] inputArgs)
		{

			Check.CheckLength(0, inputArgs);
			AuthenticationManager.Authorize();
			

			User currnetUser = AuthenticationManager.GetCurrentUser();

			using (TeamBuilderContext context = new TeamBuilderContext())
			{
				User user = context.Users.FirstOrDefault(u => u.Username == currnetUser.Username);

					user.IsDeleted = true;
					context.SaveChanges();
					AuthenticationManager.Logout();
				
				context.SaveChanges();
			}

			return $"User {currnetUser.Username} was deleted successfully !";
		}


	}
}