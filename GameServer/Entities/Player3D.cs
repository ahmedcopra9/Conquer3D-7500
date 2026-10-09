namespace Conquer3D_7500.GameServer.Entities
{
    public class Player3D
    {
        public uint UID;
        public string Name;
        public float X = 430f;
        public float Y = 380f;
        public float Z = 0f;
        public ushort MapID = 1002;
        public int HP = 5000;

        // حركة 3D الحقيقية
        public void Move3D(float newX, float newY, float newZ)
        {
            X = newX;
            Y = newY;
            Z = newZ;
        }
    }
}
