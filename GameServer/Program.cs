using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Conquer3D_7500.GameServer.Entities;
using Conquer3D_7500.GameServer.Packets;

namespace GameServer
{
    class Program
    {
        static Dictionary<int, Player3D> Players = new Dictionary<int, Player3D>();

        static void Main()
        {
            Console.Title = "Conquer3D Game - TwinCity 1002";
            Console.WriteLine("=== Conquer3D 7500 Game Server [3D] ===");

            // لاعب افتراضي
            var ahmed = new Player3D();
            Players.Add(ahmed.UID, ahmed);

            TcpListener listener = new TcpListener(IPAddress.Any, 5816);
            listener.Start();
            Console.WriteLine("Game Started on Map 1002 TwinCity - Port 5816");
            Console.WriteLine($"Player Spawned: {ahmed.Name} X:{ahmed.X} Y:{ahmed.Y} Z:{ahmed.Z}");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"Game Client: {client.Client.RemoteEndPoint}");
                var stream = client.GetStream();

                byte[] buffer = new byte[4096];
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read <= 0) continue;

                string text = Encoding.ASCII.GetString(buffer, 0, read);
                Console.WriteLine($"Packet: {text}");

                if (text.StartsWith("MOVE"))
                {
                    var move = MsgMove3D.Decode(buffer);
                    if (move!= null)
                    {
                        move.Process(ahmed);
                        byte[] ok = move.Encode();
                        stream.Write(ok, 0, ok.Length);
                    }
                }
                else if (text.StartsWith("ATTACK"))
                {
                    var atk = MsgAttack3D.Decode(buffer);
                    if (atk!= null)
                    {
                        // للتجربة هنضرب نفسه
                        atk.Process(ahmed, ahmed);
                        byte[] ok = atk.Encode(ahmed.HP);
                        stream.Write(ok, 0, ok.Length);
                    }
                }
                client.Close();
            }
        }
    }
}
