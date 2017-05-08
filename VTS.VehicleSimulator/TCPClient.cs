using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace VTS.VehicleSimulator
{
    class VehicleTCPClient
    {
        private string _serverIp;
        private int _port;
        public VehicleTCPClient(string serverIP, int port)
        {
            _serverIp = serverIP;
            _port = port;
        }

        private String response = String.Empty;

        private IPEndPoint GetServerIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(_serverIp);

            IPAddress ipAddress = ipHostInfo.AddressList[1];

            IPEndPoint remoteEP = new IPEndPoint(ipAddress, _port);

            return remoteEP;
        }

        public void Start()
        {
            TcpClient client = new TcpClient();

            Connect(client);

        }

        private void Connect(TcpClient client)
        {
            try
            {
                client.Connect(GetServerIP());
                var stream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("VLUR4X20009093588");
                stream.Write(bytesToSend, 0, bytesToSend.Length);
                client.Close();
                
            }
            catch (Exception e)
            {
                
                //Connect(client);
            }

        }
    }
}
