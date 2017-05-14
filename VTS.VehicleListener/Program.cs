using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace VTS.VehicleListener
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new VehicleTCPListener();

            listener.Start();

            Console.ReadKey();
        }
    }
}
