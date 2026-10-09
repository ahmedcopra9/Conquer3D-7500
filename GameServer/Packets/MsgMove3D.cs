using System;
using Conquer3D_7500.GameServer.Entities;

namespace Conquer3D_7500.GameServer.Packets
{
    public class MsgMove3D
    {
        public float X;
        public float Y;
        public float Z;
        public int MapID;

        public static MsgMove3D Decode(byte[] data)
        {
            try
            {
                string str = System.Text.Encoding.ASCII.GetString(data);
                if (!str.StartsWith("MOVE")) return null;
                string[] parts = str.Split('|');
                return new MsgMove3D
                {
                    X = float.Parse(parts[1]),
                    Y = float.Parse(parts[2]),
                    Z = float.Parse(parts[3]),
                    MapID = int.Parse(parts[4])
                };
            }
            catch { return null; }
        }

        public void Process(Player3D player)
        {
            player.Move(X, Y, Z);
        }

        public byte[] Encode()
        {
            return System.Text.Encoding.ASCII.GetBytes($"MOVE_OK|{X}|{Y}|{Z}|{MapID}");
        }
    }
}
