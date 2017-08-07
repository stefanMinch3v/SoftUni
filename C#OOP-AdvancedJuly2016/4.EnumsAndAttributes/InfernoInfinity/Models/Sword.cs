namespace InfernoInfinity
{
    public class Sword : Weapon
    {
        private const int maxDamage = 6;
        private const int minDamage = 4;
        private const int numOfSockets = 3;

        public Sword(string rareLevel, string name)
            : base(rareLevel, name, maxDamage, minDamage, numOfSockets)
        {
        }
    }
}