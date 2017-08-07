namespace KingsGambit
{
    using System;

    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    public class King
    {
        public event KingUnderAttackEventHandler KingAttacked;

        public King(string name) 
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void RespondAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            OnKingAttacked(new EventArgs());
        }

        protected void OnKingAttacked(EventArgs args)
        {
            KingAttacked?.Invoke(this, args);
        }
    }
}
