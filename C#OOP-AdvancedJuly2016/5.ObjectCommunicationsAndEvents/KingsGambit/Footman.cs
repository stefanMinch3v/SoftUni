using System;

namespace KingsGambit
{
    public class Footman : Soldier
    {
        public Footman(string name) 
            : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {base.Name} is panicking!");
        }
    }
}
