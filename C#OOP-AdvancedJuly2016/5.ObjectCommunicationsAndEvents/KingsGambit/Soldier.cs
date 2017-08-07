namespace KingsGambit
{
    using System;

    public abstract class Soldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs args);
    }
}
