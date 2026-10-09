using System;
using Conquer3D_7500.GameServer.Entities;

namespace Conquer3D_7500.GameServer.Packets
{
    public class MsgAttack3D
    {
        public int AttackerUID;
        public int TargetUID;
        public int Damage;

        public static MsgAttack3D Decode(byte[] data)
        {
            try
            {
                string str = System.Text.Encoding.ASCII.GetString(data);
                if (!str.StartsWith("ATTACK")) return null;
                string[] p = str.Split('|');
                return new MsgAttack3D
                {
                    AttackerUID = int.Parse(p[1]),
                    TargetUID = int.Parse(p[2]),
                    Damage = int.Parse(p[3])
                };
            }
            catch { return null; }
        }

        public void Process(Player3D attacker, Player3D target)
        {
            Random rnd = new Random();
            int realDamage = rnd.Next(100, 500); // دمج عشوائي 100-500

            target.HP -= realDamage;
            if (target.HP < 0) target.HP = 0;

            Console.WriteLine($"[3D Attack] {attacker.Name} -> {target.Name} Damage:{realDamage} HP Left:{target.HP}");

            if (target.HP == 0)
            {
                Console.WriteLine($"[DEATH] {target.Name} Died!");
                target.HP = target.MaxHP; // يصحى تاني
                target.X = 430; target.Y = 380; target.Z = 0; // يرجع توين
            }
        }

        public byte[] Encode(int newHP)
        {
            return System.Text.Encoding.ASCII.GetBytes($"ATTACK_OK|{TargetUID}|{Damage}|{newHP}");
        }
    }
}
