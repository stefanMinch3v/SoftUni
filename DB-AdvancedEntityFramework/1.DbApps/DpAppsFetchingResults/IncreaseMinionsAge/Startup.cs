namespace IncreaseMinionsAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] minionsIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                for (int i = 0; i < minionsIds.Length; i++)
                {
                    string increaseAgeQueryAndUpdateName = $@"UPDATE Minions
                                                            SET Name = UPPER(LEFT(Name, 1)) + RIGHT(Name, LEN(Name) -1), Age+=1
                                                            WHERE MinionId = @MinionId"; // type lower to test or see the age

                    SqlCommand cmdIncreaseMinionAge = new SqlCommand(increaseAgeQueryAndUpdateName, connection);
                    cmdIncreaseMinionAge.Parameters.AddWithValue("@MinionId", minionsIds[i]);
                    cmdIncreaseMinionAge.ExecuteNonQuery();
                }

                string selectNameAndAgeFromMinions = $@"SELECT m.Name, m.Age
                                                        FROM Minions AS m";

                SqlCommand cmd = new SqlCommand(selectNameAndAgeFromMinions, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }
    }
}
