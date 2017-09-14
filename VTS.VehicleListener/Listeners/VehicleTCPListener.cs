using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using VTS.BL;
using VTS.DependencyInjectionRegister;
using Autofac;
using System.Linq;

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


        /// <summary>
        /// Returns the server IP where clients connects to
        /// </summary>
        /// <returns></returns>
        private IPEndPoint GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress ipAddress = ipHostInfo.AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();

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

                Console.WriteLine("Listening to:" + listener.LocalEndpoint);

                while (true)
                {
                    client = listener.AcceptTcpClient();


                    Task.Factory.StartNew(() => ProcessData(client));
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
        private void ProcessData(TcpClient client)
        {
            try
            {
                Byte[] bytes = new Byte[256];

                try
                {
                    var stream = client.GetStream();

                    var bytesToRead = new byte[client.ReceiveBufferSize];

                    var bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);

                    var vehicleId = new ResponseHandler().HandleResponse(bytesToRead,bytesRead);

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
