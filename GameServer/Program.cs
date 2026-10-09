using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Conquer3D_7500.GameServer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Game Server 7500 - 3D ===");
            TcpListener listener = new TcpListener(IPAddress.Any, 5816);
            listener.Start();
            Console.WriteLine("Game Started on TwinCity 1002 - X430 Y380 Z0");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Player In: " + client.Client.RemoteEndPoint);
                byte[] welcome = Encoding.ASCII.GetBytes("WELCOME_3D");
                client.GetStream().Write(welcome, 0, welcome.Length);
            }
        }
    }
}
