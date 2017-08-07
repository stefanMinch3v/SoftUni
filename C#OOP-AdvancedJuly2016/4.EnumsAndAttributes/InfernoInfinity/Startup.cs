namespace InfernoInfinity
{
    using Factory;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            //practise the excercise without enums : 20 percent in judge 
            List<Weapon> allWeapons = new List<Weapon>();
            WeaponFactory weaponFactory = new WeaponFactory();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var commandLine = input.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                string firstCommand = commandLine[0];
                string weaponName = commandLine[1];

                switch (firstCommand)
                {
                    case "Create":
                        allWeapons.Add(weaponFactory.CreateWeapon(commandLine[1], commandLine[2]));
                        break;
                    case "Add":
                        int index = int.Parse(commandLine[2]);
                        string gemType = commandLine[3];

                        var weapon = allWeapons.First(w => w.Name == weaponName);
                        weapon.AddGem(gemType, index);
                        weapon.CalculateGemStatus();
                        break;
                    case "Remove":
                        var removeWeapon = allWeapons.First(w => w.Name == weaponName);
                        int indexToRemove = int.Parse(commandLine[2]);

                        removeWeapon.Remove(indexToRemove);
                        removeWeapon.RepairSocketAfterRemove();
                        break;
                    case "Print":
                        var currentWeapon = allWeapons.First(w => w.Name == weaponName);
                        Console.WriteLine(currentWeapon);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

        }
    }
}
