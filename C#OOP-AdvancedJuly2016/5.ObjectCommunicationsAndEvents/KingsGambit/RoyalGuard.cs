using System;

namespace KingsGambit
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) 
            : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {base.Name} is defending!");
        }
    }
}
