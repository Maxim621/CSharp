using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharp.Homework16.ServerChat
{
    class UDPServer
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12346);
            server.Client.Bind(endPoint);

            Console.WriteLine("UDP Server started.");

            while (true)
            {
                byte[] data = server.Receive(ref endPoint);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("Received: " + message);

                // Respond with server information
                string serverInfo = "Server IP: " + GetLocalIPAddress();
                byte[] response = Encoding.UTF8.GetBytes(serverInfo);
                server.Send(response, response.Length, endPoint);
            }
        }

        static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No IP found";
        }
    }
}
