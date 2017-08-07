namespace TrafficLights
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            string firstLight = input[0];
            string secondLight = input[1];
            string thirdLight = input[2];

            int numberOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChanges; i++)
            {
                var temp = input[0];
                var temp2 = input[1];
                input[0] = input[2];
                input[1] = temp;
                input[2] = temp2;
                Console.WriteLine(string.Join(" ", input));
            }

            //this is the correct solution of my college
            //var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //List<Lights> listColors = input.Select(lightColor => (Lights)Enum.Parse(typeof(Lights), lightColor)).ToList();

            //int updates = int.Parse(Console.ReadLine());
            //for (int i = 0; i < updates; i++)
            //{
            //    int realEnumUpdater = i + 1;
            //    Console.WriteLine(ChangeLight(listColors, realEnumUpdater));
            //}

        }

        //private static string ChangeLight(List<LightColor> listColors, int realEnumUpdater)
        //{
        //    var allColors = listColors.Select(c => (LightColor)( ((int)c + realEnumUpdater) % 3) ).Select(x => x.ToString()).ToList();

        //    return string.Join(" ", allColors);
        //}
    }

    //public enum Lights
    //{
    //    Red,
    //    Green,
    //    Yellow
    //}
}
