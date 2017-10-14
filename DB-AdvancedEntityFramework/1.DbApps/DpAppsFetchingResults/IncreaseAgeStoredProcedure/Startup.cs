namespace IncreaseAgeStoredProcedure
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                SqlCommand procCommand = new SqlCommand("usp_GetOlder", connection);
                procCommand.CommandType = CommandType.StoredProcedure;
                procCommand.Parameters.AddWithValue("@MinionId", minionId);
                procCommand.ExecuteNonQuery();


                string getMinionsQuery = $@"SELECT m.Name, m.Age
                                            FROM Minions AS m
                                            WHERE m.MinionID = {minionId}";

                SqlCommand cmd = new SqlCommand(getMinionsQuery, connection);
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
