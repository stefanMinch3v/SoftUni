namespace GetVillainsNames
{
    using System;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

                using (connection)
                {
                    string searchQuery = @"SELECT v.Name, COUNT(mv.MinionId) AS [Count minions]
                                            FROM Villians AS v
                                            INNER JOIN MinionsVillians AS mv
	                                            ON v.VillianId = mv.VillianId
                                            GROUP BY v.Name
                                            HAVING COUNT(mv.VillianId) > 1
                                            ORDER BY [Count minions] DESC"; // count must be > 3 but in my case i have entries with max 2

                    SqlCommand cmd = new SqlCommand(searchQuery, connection);
                    var reader = cmd.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} -- {reader[1]}");
                        }
                    }
            }
        }
    }
}
