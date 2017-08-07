namespace ListyIteratorSolution
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            ListIterator<string> myList = new ListIterator<string>();

            var input = Console.ReadLine();

            foreach (var item in myList)
            {

            }

            while (input != "END" || myList.Count() == 100)
            {
                var commandLine = input.Split();
                try
                {
                    switch (commandLine[0])
                    {
                        case "Create":
                            myList.AddRange(commandLine.Skip(1).ToArray());
                            break;
                        case "Move":
                            Console.WriteLine(myList.MoveNext());
                            break;
                        case "HasNext":
                            Console.WriteLine(myList.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(myList.Current);
                            break;
                        case "PrintAll":
                            
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                input = Console.ReadLine();
            }
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
