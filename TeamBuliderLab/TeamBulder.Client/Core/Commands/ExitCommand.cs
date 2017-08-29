using System;
using TeamBulder.Client.Utilities;

namespace TeamBulder.Client.Core.Commands
{
	public class ExitCommand
	{
		public  string Execute(string[] inputArgs)
		{
			Check.CheckLength(0,inputArgs);

			Environment.Exit(0);

			return "Bye!";
		}
	}
}
