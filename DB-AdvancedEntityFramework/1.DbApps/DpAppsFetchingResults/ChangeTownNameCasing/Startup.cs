namespace ChangeTownNameCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            string country = Console.ReadLine();

            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            try
            {
                using (connection)
                {
                    string updateCountry = @"UPDATE Towns
                                        SET Name = UPPER(Name)
                                        WHERE Country = @Country";

                    string getUpdatedTowns = @"SELECT Name
                                                FROM Towns
                                                WHERE Country = @Country";

                    SqlCommand cmdUpdate = new SqlCommand(updateCountry, connection);
                    cmdUpdate.Parameters.AddWithValue("@Country", country);
                    int countChanges = cmdUpdate.ExecuteNonQuery();

                    if (countChanges == 0)
                    {
                        throw new Exception("No town names were affected.");
                    }

                    Console.WriteLine($"{countChanges} town names were affected.");

                    SqlCommand cmdChanged = new SqlCommand(getUpdatedTowns, connection);
                    cmdChanged.Parameters.AddWithValue("@Country", country);
                    var reader = cmdChanged.ExecuteReader();
                    var list = new List<string>();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }

                    var result = string.Join(", ", list);
                    Console.WriteLine($"[{result}]");
                    //StringBuilder sb = new StringBuilder();
                    //using (reader)
                    //{
                    //    sb.Append("[");
                    //    while (reader.Read())
                    //    {
                    //        sb.Append($"{reader[0]}, ");
                    //    }
                    //    sb.Remove(sb.Length - 2, 2);
                    //    sb.Append("]");
                    //}
                    //Console.WriteLine(sb);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
