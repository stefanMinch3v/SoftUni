namespace BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;
    using Attributes;

    class Engine : IRunnable
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;
        [Inject]
        private ICommandInterpreter commandInterpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory, ICommandInterpreter commandInterpreter)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandInterpreter.InterpretCommand(data, commandName).Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //private string ReportCommand(string[] data)
        //{
        //    string output = this.repository.Statistics;
        //    return output;
        //}


        //private string AddUnitCommand(string[] data)
        //{
        //    string unitType = data[1];
        //    IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        //    this.repository.AddUnit(unitToAdd);
        //    string output = unitType + " added!";
        //    return output;
        //}
    }
}
