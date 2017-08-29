using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBulder.Client.Core;

namespace TeamBulder.Client
{
	class Application
	{
		static void Main(string[] args)
		{
			Engine engine = new Engine(new CommandDispatcher());

			engine.Run();
		}
	}
}
