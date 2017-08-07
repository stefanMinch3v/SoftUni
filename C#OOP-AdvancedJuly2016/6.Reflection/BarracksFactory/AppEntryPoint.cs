namespace BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    public class AppEntryPoint
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter interpreter = new CommandManager();
            IRunnable engine = new Engine(repository, unitFactory, interpreter);
            engine.Run();
        }
    }
}
