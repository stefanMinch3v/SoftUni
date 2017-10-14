namespace RemoveVillain
{
    using System;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            int villianId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                string sqlDeleteFromMinionsVillians = @"DELETE FROM MinionsVillians 
                                    WHERE VillianId = @VillianId";

                string sqlGetName = @"SELECT v.Name
                                    FROM Villians AS v
                                    WHERE v.VillianId = @VillianId";

                string sqlDeleteFromVillian = @"DELETE FROM Villians
                                                WHERE VillianId = @VillianId";

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand cmdGetName = new SqlCommand(sqlGetName, connection, transaction);
                    cmdGetName.Parameters.AddWithValue("@VillianId", villianId);
                    string villianName = cmdGetName.ExecuteScalar()?.ToString();

                    if (villianName == null)
                    {
                        throw new Exception("No such villain was found");
                    }

                    SqlCommand cmdDeleteMapTable = new SqlCommand(sqlDeleteFromMinionsVillians, connection, transaction);
                    cmdDeleteMapTable.Parameters.AddWithValue("@VillianId", villianId);
                    int countDeletedMinions = cmdDeleteMapTable?.ExecuteNonQuery() ?? 0;

                    SqlCommand cmdDeleteVillian = new SqlCommand(sqlDeleteFromVillian, connection, transaction);
                    cmdDeleteVillian.Parameters.AddWithValue("@VillianId", villianId);
                    cmdDeleteVillian.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine($"{villianName} was deleted");
                    Console.WriteLine($"{countDeletedMinions} minions released");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                }
            }
        }
    }
}
