using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] input = Console.ReadLine().Split();
            //List<string> finalResult = new List<string>();
   
            while (! input[0].Equals("end"))
            {
                string command = input[0];
                //List<string> final = new List<string>();
                string convert = string.Empty;
                int start = 0;
                int count = 0;
                int times = 0;
                

                switch (command)
                {
                    case "reverse":
                        start = int.Parse(input[2]);// start index
                        count = int.Parse(input[4]);// how many counts

                        if (start < 0 
                            || count < 0 
                            || (start + count) > numbers.Count
                            || start >= numbers.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        string[] reverse = numbers.Skip(start).Take(count).Reverse().ToArray();
                        numbers.RemoveRange(start, count);
                        numbers.InsertRange(start, reverse);

                        //for (int i = 0; i < start; i++)
                        //{
                        //    numbers.Add(numbers[i]);
                        //}
                        //numbers.AddRange(reverse);
                        //for (int i = count + start; i < numbers.Count; i++)
                        //{
                        //    numbers.Add(numbers[i]);
                        //}
                        //convert = string.Join(", ", numbers);
                        //finalResult.Add(convert);
                        break;
                    case "sort":
                        start = int.Parse(input[2]);// start index
                        count = int.Parse(input[4]);// how many counts
                        if (start < 0 
                            || count < 0 
                            || (start + count) > numbers.Count
                            || start >= numbers.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        string[] sort = numbers.Skip(start).Take(count).OrderBy(str => str).ToArray(); // parse to int because when is string it cannot order it correctly(10 is taken for 1)!!
                        numbers.RemoveRange(start, count);
                        numbers.InsertRange(start, sort);

                        //final = new List<string>();
                        //for (int i = 0; i < start; i++)
                        //{
                        //    final.Add(numbers[i]);
                        //}
                        //final.AddRange(sort);
                        //for (int i = count + start; i < numbers.Count; i++)
                        //{
                        //    final.Add(numbers[i]);
                        //}
                        //convert = string.Join(", ", final);
                        //finalResult.Add(convert);
                        break;
                    case "rollLeft":
                        times = int.Parse(input[1]);// converting times
                        if (times < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }
                        //List<string> rollLeft = numbers;

                        for (int i = 0; i < times % numbers.Count; i++)
                        {
                            string first = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(first);
                        }

                        //string left = string.Join(", ", rollLeft);
                        //finalResult.Add(left);
                        break;
                    case "rollRight":
                        times = int.Parse(input[1]);// converting times
                        if (times < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        //List<string> rollRight = numbers;

                        for (int i = 0; i < times % numbers.Count; i++)
                        {
                            string last = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, last);
                        }

                        //string rights = string.Join(", ", rollRight);
                        //finalResult.Add(rights);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine().Split();
            }

            string result = string.Join(", ", numbers);
            Console.WriteLine($"[{result}]");

        }
    }
}
