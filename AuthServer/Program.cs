using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AuthServer
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Conquer3D Auth - 9960";
            Console.WriteLine("=== Conquer3D 7500 Auth Server [3D] ===");
            Console.WriteLine("Starting on Port 9960... Login: admin / admin");

            TcpListener listener = new TcpListener(IPAddress.Any, 9960);
            listener.Start();
            Console.WriteLine("Auth Started on 9960 - Waiting for clients...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"Client Connected: {client.Client.RemoteEndPoint}");

                var stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int read = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.ASCII.GetString(buffer, 0, read);
                Console.WriteLine($"Login Attempt: {data}");

                // لو بعت admin/admin دخله
                if (data.Contains("admin"))
                {
                    string response = "AUTH_OK|1000001|Ahmed3D|1002|430|380|0";
                    byte[] resp = Encoding.ASCII.GetBytes(response);
                    stream.Write(resp, 0, resp.Length);
                    Console.WriteLine("Login Success: Ahmed3D");
                }
                client.Close();
            }
        }
    }
}
