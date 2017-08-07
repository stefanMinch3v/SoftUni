namespace BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unit = unitFactory.CreateUnit(Data[1]);
            repository.AddUnit(unit);
            return Data[1] + " added!"; 
        }
    }
}
