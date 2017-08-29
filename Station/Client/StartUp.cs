using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationsExam.Data;
using StationsExam.Models;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ctx = new StationContext();
            ctx.Database.Initialize(true);
        }
    }
}
