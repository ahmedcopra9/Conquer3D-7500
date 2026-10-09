using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Conquer3D_7500.AuthServer
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Conquer3D Auth 7500 ===");
            TcpListener listener = new TcpListener(IPAddress.Any, 9960);
            listener.Start();
            Console.WriteLine("Auth Started on 9960 - login: admin/admin");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Client: " + client.Client.RemoteEndPoint);
                var stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int read = stream.Read(buffer, 0, buffer.Length);
                string req = Encoding.ASCII.GetString(buffer, 0, read);
                Console.WriteLine("Login: " + req);

                string res = "AUTH_OK|127.0.0.1|5816";
                byte[] data = Encoding.ASCII.GetBytes(res);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
