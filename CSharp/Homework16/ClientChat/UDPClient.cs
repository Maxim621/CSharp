using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSharp.Homework16.ClientChat
{
    class UDPClient
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 12346);

            string message = "Server Discovery Request";
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, endPoint);

            Console.WriteLine("Discovery request sent.");

            IPEndPoint responseEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] responseData = client.Receive(ref responseEndPoint);
            string responseMessage = Encoding.UTF8.GetString(responseData);
            Console.WriteLine("Received response: " + responseMessage);
        }
    }
}
