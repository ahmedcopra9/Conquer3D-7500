using System;
using System.Net;
using System.Net.Sockets;

namespace Conquer3D_7500
{
    class AuthServer
    {
        static void Main()
        {
            Console.WriteLine("=== Conquer 3D 7500 Auth Started ===");
            Console.WriteLine("Port: 9960");
            TcpListener listener = new TcpListener(IPAddress.Any, 9960);
            listener.Start();
            Console.WriteLine("Waiting for 7500 client...");

            while(true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"New client: {client.Client.RemoteEndPoint}");
                // هنا هنضيف فك تشفير 7500 بعدين
            }
        }
    }
}
