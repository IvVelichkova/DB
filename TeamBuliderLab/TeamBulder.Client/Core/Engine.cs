﻿using System;

namespace TeamBulder.Client.Core
{
	public class Engine
	{
		private  CommandDispatcher commandDispatcher;

		public Engine(CommandDispatcher commandDispatcher)
		{
			this.commandDispatcher = commandDispatcher;
		}

		public void Run()
		{
			while (true)
			{
				try
				{
					string input = Console.ReadLine();
					string output = this.commandDispatcher.Dispatch(input);
					Console.WriteLine(output);
				}
				catch (Exception e)
				{

					Console.WriteLine(e.GetBaseException().Message);
				}
			}

		}


		
	}

}
