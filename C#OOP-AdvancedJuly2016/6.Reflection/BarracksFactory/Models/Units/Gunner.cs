namespace BarracksFactory.Models.Units
{
    public class Gunner : Unit
    {
        private const int health = 20;
        private const int attackDamage = 20;

        public Gunner() 
            : base(health, attackDamage)
        {
        }
    }
}
