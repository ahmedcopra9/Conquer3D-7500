using System;

namespace Conquer3D_7500.GameServer.Entities
{
    public class Player3D
    {
        public int UID { get; set; } = 1000001;
        public string Name { get; set; } = "Ahmed3D";
        public int MapID { get; set; } = 1002;

        // الـ 3D الحقيقي
        public float X { get; set; } = 430f;
        public float Y { get; set; } = 380f;
        public float Z { get; set; } = 0f;

        public int HP { get; set; } = 5000;
        public int MaxHP { get; set; } = 5000;

        public void Move(float newX, float newY, float newZ)
        {
            X = newX;
            Y = newY;
            Z = newZ;
            Console.WriteLine($"[3D Move] {Name} Moved to X:{X} Y:{Y} Z:{Z} Map:{MapID}");
        }

        public byte[] ToSpawnPacket()
        {
            string data = $"SPAWN|{UID}|{Name}|{X}|{Y}|{Z}|{MapID}|{HP}";
            return System.Text.Encoding.ASCII.GetBytes(data);
        }
    }
}
