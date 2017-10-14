namespace GetMinionNames
{
    using System.Data.SqlClient;
    using System;

    public class Startup
    {
        public static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            Console.Write("Enter villian id: ");
            int villianNumber = int.Parse(Console.ReadLine());

            using (connection)
            {
                string villianNameQuery = @"SELECT v.Name 
                                        FROM Villians AS v
                                        WHERE v.VillianID = @InputNumber";

                SqlCommand cmdVillian = new SqlCommand(villianNameQuery, connection);
                cmdVillian.Parameters.AddWithValue("@InputNumber", villianNumber);
                var result = cmdVillian.ExecuteScalar() ?? null;

                if (result == null)
                {
                    Console.WriteLine($"No villain with ID {villianNumber} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villian: {result}");

                string allMinionsRelatedToVillianQuery = @"SELECT m.Name, m.Age
                                                            FROM Minions AS m
                                                            INNER JOIN MinionsVillians AS mv
	                                                            ON mv.MinionId = m.MinionId
                                                            WHERE mv.VillianId = @InputNumber";

                SqlCommand cmdMinions = new SqlCommand(allMinionsRelatedToVillianQuery, connection);
                cmdMinions.Parameters.AddWithValue("@InputNumber", villianNumber);
                var reader = cmdMinions.ExecuteReader();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                        return;
                    }

                    int counter = 1;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{counter}. {reader[0]} {reader[1]}");
                        counter++;
                    }
                }
            }
        }
    }
}
