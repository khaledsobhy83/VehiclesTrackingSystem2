using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using VTS.BL;
using VTS.DependencyInjectionRegister;
using Autofac;

namespace VTS.VehicleListener
{
    class VehicleTCPListener : IListner
    {
        private TcpListener listener;
        private const int PortNumber = 5555;


        public VehicleTCPListener()
        {
            listener = new TcpListener(GetServerIP());
        }

        private IPEndPoint GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PortNumber);

            return localEndPoint;
        }
        /// <summary>
        /// Initailizes the listener
        /// </summary>
        public void Initialize()
        {
            //In our case nothing needed here but generally may be needed with other types of listeners
        }

        /// <summary>
        /// Start listening for client connections
        /// </summary>
        public void Start()
        {
            try
            {
                TcpClient client;

                listener.Start();

                while (true)
                {
                    client = listener.AcceptTcpClient();

                    ThreadPool.QueueUserWorkItem(ProcessData, client);
                }

            }
            catch (Exception e)
            {
                //ToDO: Log Exception
            }
        }
        /// <summary>
        /// Process the retrieved data from clients
        /// </summary>
        /// <param name="obj">TCP Client</param>
        private void ProcessData(object obj)
        {
            try
            {
                var client = (TcpClient)obj;

                Byte[] bytes = new Byte[256];

                try
                {
                    var stream = client.GetStream();

                    var bytesToRead = new byte[client.ReceiveBufferSize];

                    var bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);

                    var vehicleId = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);

                   new ResponseHandler().HandleResponse(vehicleId);

                    Console.WriteLine("Received : " + vehicleId);

                    Console.ReadLine();
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
           
        /// <summary>
        /// Stops listening
        /// </summary>
        public void Stop()
        {
            listener.Stop();

        }
        

    }
}
