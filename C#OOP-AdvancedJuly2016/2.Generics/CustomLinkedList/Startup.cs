namespace CustomLinkedList
{
    public class Startup
    {
        public static void Main()
        {
            LinkedList<int> myList = new LinkedList<int>();
            myList.Add(100);
            myList.Add(200);
            myList.Add(300);

            myList.RemoveFirst(200);
            foreach (var item in myList)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
