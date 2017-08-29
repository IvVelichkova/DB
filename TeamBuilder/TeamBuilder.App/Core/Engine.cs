using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.App.Core
{
    public class Engine
    {
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                    throw;
                }
            }
        }
    }
}
