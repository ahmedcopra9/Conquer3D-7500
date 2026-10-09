using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Conquer3D_7500.Loader
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Conquer3D 7500 - 3D Loader ===");
            Console.Title = "Conquer3D Loader";

            string conquerExe = @"C:\Conquer3D_7500\Conquer.exe";
            string serverIP = "127.0.0.1";
            int authPort = 9960;
            string serverName = "Conquer3D-7500 [3D]";

            // 1. نعمل ملف Server.dat
            Console.WriteLine("Creating Server.dat...");
            string serverDatPath = Path.Combine(Path.GetDirectoryName(conquerExe), "Server.dat");

            // فورمات السيرفر دات بتاع كونكر 7500
            string serverDatContent = $"{serverName}\t{serverIP}\t{authPort}\t0\t0";

            try
            {
                if (Directory.Exists(Path.GetDirectoryName(conquerExe)))
                {
                    File.WriteAllText(serverDatPath, serverDatContent);
                    Console.WriteLine($"Server.dat Created: {serverDatContent}");
                }
                else
                {
                    Console.WriteLine($"[WARNING] Conquer path not found: {Path.GetDirectoryName(conquerExe)}");
                    Console.WriteLine($"Creating local Server.dat for testing...");
                    File.WriteAllText("Server.dat", serverDatContent);
                }

                // 2. نشغل اللعبة
                Console.WriteLine($"Starting {conquerExe}...");
                Console.WriteLine($"Login: admin / admin");
                Console.WriteLine($"Auth Server: {serverIP}:{authPort}");

                if (File.Exists(conquerExe))
                {
                    Process.Start(conquerExe, "blacknull");
                    Console.WriteLine("Game Started! Have fun in 3D!");
                }
                else
                {
                    Console.WriteLine("Conquer.exe not found. Please install client 7500 in C:\\Conquer3D_7500\\");
                    Console.WriteLine("You can download 7500 client from conquer downloads.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
