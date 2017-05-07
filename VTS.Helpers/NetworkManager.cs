using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace VTS.Helpers
{
    public class NetworkManager
    {
        public static bool PingVehicle(string address)
        {
            Ping ping = new Ping();

            var reply = ping.Send(address);

            return reply.Status == IPStatus.Success;
        }
    }
}
