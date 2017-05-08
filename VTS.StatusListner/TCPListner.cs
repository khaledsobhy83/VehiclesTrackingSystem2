using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace VTS.StatusListner
{
    class VehicleTCPListener
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private static IPEndPoint GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1506);
            return localEndPoint;
        }

        public static void Start()
        {
            try
            {
                TcpListener listener = new TcpListener(GetServerIP());
                TcpClient client;
                listener.Start();

                while (true)
                {
                    client = listener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(threadProc, client);
                }


            }
            catch (Exception e)
            {
                //ToDO: Log Exception
            }
        }
        private static void threadProc(object obj)
        {
            try
            {
                var client = (TcpClient)obj;

                Byte[] bytes = new Byte[256];
                string data = null;

                try
                {
                    NetworkStream stream = client.GetStream();

                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine(">{0}: {1}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(), data);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(">>{0} Lost Connection...", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
