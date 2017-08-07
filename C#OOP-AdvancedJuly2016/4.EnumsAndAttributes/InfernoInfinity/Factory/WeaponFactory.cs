namespace InfernoInfinity.Factory
{
    public class WeaponFactory
    {
        public Weapon CreateWeapon(string weaponParams, string weaponName)
        {
            string[] typeAndRarity = weaponParams.Split();
            string rareLevel = typeAndRarity[0];
            string type = typeAndRarity[1];

            if (type == "Axe")
            {
                return new Axe(rareLevel, weaponName);
            }
            else if (type == "Sword")
            {
                return new Sword(rareLevel, weaponName);
            }
            else if (type == "Knife")
            {
                return new Knife(rareLevel, weaponName);
            }

            return null;
        }
    }
}
