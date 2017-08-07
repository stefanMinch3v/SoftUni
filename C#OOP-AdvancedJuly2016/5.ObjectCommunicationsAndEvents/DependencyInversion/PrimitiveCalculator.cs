namespace DependencyInversion
{
    using Interfaces;
    using Models;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy initStrategy)
        {
            this.strategy = initStrategy;
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)  
            {
                case '+':
                    this.strategy = new AdditionStrategy();
                    break;
                case '-':
                    this.strategy = new SubtractionStrategy();
                    break;
                case '/':
                    this.strategy = new DivideStrategy();
                    break;
                case '*':
                    this.strategy = new MultiplyStrategy();
                    break;
                default:
                    break;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
