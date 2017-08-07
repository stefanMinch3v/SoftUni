using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kermen.Factories
{
    static class HouseHoldFactory
    {
        public static HouseHold CreateHouseHolder(string input)
        {
            string pattern = @"(\w+)\(([\d\.\s,]+)\)";
            Regex regex = new Regex(pattern);
            MatchCollection collection = regex.Matches(input);

            if (!regex.IsMatch(input))
            {
                throw new ArgumentException("Invalid input");
            }

            string houseHold = collection[0].Groups[1].Value;

            switch (houseHold)
            {
                case "YoungCouple":
                    return CreateYoungCouple(collection);
                case "YoungCoupleWithChildren":
                    return CreateYoungCoupleWithChildren(collection);
                case "OldCouple":
                    return CreateAnOldCouple(collection);
                case "AloneOld":
                    return CreateAloneOld(collection);
                case "AloneYoung":
                    return CreateAloneYoung(collection);
                default:
                    throw new ArgumentException("Invalid input");
            }


        }

        private static HouseHold CreateAloneOld(MatchCollection collection)
        {
            decimal pension = decimal.Parse(collection[0].Groups[2].Value);

            return new AloneOld(pension);
        }

        private static HouseHold CreateAnOldCouple(MatchCollection collection)
        {
            decimal[] pensions = collection[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvCost = decimal.Parse(collection[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(collection[2].Groups[2].Value);
            decimal stoveCost = decimal.Parse(collection[3].Groups[2].Value);

            return new OldCouple(pensions[0], pensions[1], tvCost, fridgeCost, stoveCost);
        }

        private static HouseHold CreateAloneYoung(MatchCollection collection)
        {
            decimal salary = decimal.Parse(collection[0].Groups[2].Value);
            decimal laptopCost = decimal.Parse(collection[1].Groups[2].Value);

            return new AloneYoung(salary, laptopCost);
        }

        private static HouseHold CreateYoungCoupleWithChildren(MatchCollection collection)
        {
            decimal[] salaries = collection[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvCost = decimal.Parse(collection[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(collection[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(collection[3].Groups[2].Value);
            Child[] children = new Child[collection.Count - 4];

            for (int i = 4; i < collection.Count; i++)
            {
                decimal[] consumptions = collection[i].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
                children[i - 4] = new Child(consumptions);
            }

            return new YoungCoupleWithChildren(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost, children);
        }

        private static HouseHold CreateYoungCouple(MatchCollection collection)
        {
            decimal[] salaries = collection[0].Groups[2].Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            decimal tvCost = decimal.Parse(collection[1].Groups[2].Value);
            decimal fridgeCost = decimal.Parse(collection[2].Groups[2].Value);
            decimal laptopCost = decimal.Parse(collection[3].Groups[2].Value);
            return new YoungCouple(salaries[0], salaries[1], tvCost, fridgeCost, laptopCost);
        }
    }
}
