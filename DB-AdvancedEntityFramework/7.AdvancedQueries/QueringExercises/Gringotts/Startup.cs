namespace Gringotts
{
    using Data;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new GrongottsContext();

            //19
            //DepositsSumOllivanderFamily(context);

            //20
            DepositsFilter(context);
        }

        private static void DepositsFilter(GrongottsContext context)
        {
            var result = context.WizzardDeposits.Where(d => d.MagicWandCreator == "Ollivander family").ToArray();
            foreach (var depositGroup in result
                                            .OrderByDescending(d => d.DepositAmount)
                                            .Select(d => d.DepositGroup)
                                            .Distinct())
            {
                var totalSum = result.Where(d => d.DepositGroup == depositGroup).Sum(d => d.DepositAmount);
                if (totalSum < 150000)
                {
                    Console.WriteLine($"{depositGroup} {totalSum}");
                }
            }
        }

        private static void DepositsSumOllivanderFamily(GrongottsContext context)
        {
            var result = context.WizzardDeposits.Where(d => d.MagicWandCreator == "Ollivander family").ToArray();
            foreach (var depositGroup in result.Select(d => d.DepositGroup).Distinct())
            {
                var totalSum = result.Where(d => d.DepositGroup == depositGroup).Sum(d => d.DepositAmount);
                Console.WriteLine($"{depositGroup} {totalSum}");
            }
        }
    }
}
