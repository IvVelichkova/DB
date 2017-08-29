using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using ExtendetQueryContext;
using Models;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ExtendetContext();
            context.Database.Initialize(true);

            context.Clients.Update(c => new Models.Client {Age = 18});
            context.SaveChanges();
        }
    }
}
