using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Console.WriteLine(ExcellentFilter(5));
    }

    public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
    {

    }

    private static void FilterAndTakeAgain(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
    {

    }

    private static bool ExcellentFilter(double mark)
    {
        return mark >= 5.00;
        //return mark >= 5.00 ? true : false;
    }

    private static bool AverageFilter(double mark)
    {
        return mark < 5.00 && mark >= 3.50;
    }

    private static bool PoorFilter(double mark)
    {
        return mark < 3.50;
    }

    private static double AverageMark(List<int> scoresOnTasks)
    {
        int totalScore = 0;
        foreach (var score in scoresOnTasks)
        {
            totalScore += score;
        }
        double percentageOfAll = totalScore / scoresOnTasks.Count;
        double mark = percentageOfAll * 4 + 2;

        return mark;
    }
}
