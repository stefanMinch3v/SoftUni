using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Plants
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        Stack<int> currentPlants = new Stack<int>();
        Stack<int> reversePlants = new Stack<int>();
        int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < n; i++)
        {
            currentPlants.Push(plants[i]);
        }

        int topPlant = currentPlants.Peek();
        reversePlants.Push(topPlant);

        for (int i = 0; i < currentPlants.Count; i++)
        {
            int checkNum = currentPlants.Peek();
            int checkReverse = reversePlants.Peek();
            if (checkReverse > checkNum)
            {
                reversePlants.Pop();
            }
            else if(checkReverse < checkNum)
            {
                currentPlants.Pop();
            }
        }
        Console.WriteLine();
    }
}
