namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                string searchQuery = @"SELECT Name FROM Minions";
                SqlCommand cmd = new SqlCommand(searchQuery, connection);
                var reader = cmd.ExecuteReader();
                List<string> list = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        list.Add(reader[0].ToString());
                    }
                }

                //way 1
                int counterUp = 0;
                int counterDown = list.Count - 1;

                while (counterUp <= counterDown)
                {
                    Console.WriteLine(list[counterUp]);
                    counterUp++;

                    if (counterUp >= counterDown)
                    {
                        break;
                    }

                    Console.WriteLine(list[counterDown]);
                    counterDown--;
                }


                //way 2
                //for (int i = 0; i < list.Count; i++)
                //{
                //    int counter = 0;
                //    for (int j = list.Count - 1; j >= 0; j--)
                //    {


                //        Console.WriteLine(list[0 + counter]);

                //        if (counter == j)
                //        {
                //            break;
                //        }

                //        Console.WriteLine(list[0 + j]);
                //        counter++;
                //    }

                //    break;
                //}

                //way 3
                //int firstIndex = 0;
                //int lastIndex = list.Count - 1;

                //for (int i = 0; i < list.Count; i++)
                //{
                //    int currentIndex;
                //    if (i % 2 == 0)
                //    {
                //        currentIndex = firstIndex;
                //        firstIndex++;
                //    }
                //    else
                //    {
                //        currentIndex = lastIndex;
                //        lastIndex--;
                //    }

                //    Console.WriteLine(list[currentIndex]);
                //}

            }
        }
    }
}
