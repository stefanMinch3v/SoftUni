namespace BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using Contracts;
    using Models.Units;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //Type t = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(x => x.Name == unitType);// goes through all the classes in the current project and checks if one of them is equal to unitType
            //IUnit unit = Activator.CreateInstance(t) as IUnit;
            //return unit;

            switch (unitType)
            {
                case "Archer":
                    return Activator.CreateInstance<Archer>();
                //var constructor = typeof(Archer).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                //var archer = constructor.Invoke(new object[] { }) as Archer;
                //return archer;
                case "Gunner":
                    return Activator.CreateInstance<Gunner>();
                case "Horseman":
                    return Activator.CreateInstance<Horseman>();
                case "Pikeman":
                    return Activator.CreateInstance<Pikeman>();
                case "Swordsman":
                    return Activator.CreateInstance<Swordsman>();
                default:
                    break;
            }

            return null;
        }
    }
}
