namespace AddMinion
{
    using System;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            Console.Write("Minion: ");
            var minion = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Villian: ");
            string villian = Console.ReadLine();

            SqlConnection connection = new SqlConnection(AddMinion.Properties.Settings.Default.ConnectionString); //easiest way to connect DB multiple active result set is enabled to true so you can open using 2 readers at the same time - its not recommended to have it true it should be false
            connection.Open();

            using (connection)
            {
                SqlTransaction transaction = connection.BeginTransaction(); //bonus task
                #region SQL QUERIES

                string getTownNameQuery = @"SELECT t.Name 
                                            FROM Towns AS t
                                            WHERE t.Name = @TownName";

                string getTownIdQuery = @"SELECT TownId FROM Towns
                                            WHERE Name = @TownName";

                string insertTownQuery = @"INSERT INTO Towns(Name)
                                            VALUES
                                            (@TownName)";

                string getMinionNameAndAge = @"SELECT m.MinionId
                                                FROM Minions AS m
                                                WHERE m.Name = @Username";

                string insertMinionQuery = @"INSERT INTO Minions(Name, Age, TownId)
                                            VALUES
                                            (@Name, @Age, @TownId)";

                string checkVillian = @"SELECT v.VillianId 
                                        FROM Villians AS v
                                        WHERE v.Name = @VillianName";

                string insertVillian = @"INSERT INTO Villians(Name, EvilnessFactor)
                                        VALUES
                                        (@VillianName, 'Evil')";

                string insertConnectionBetweenVillianAndMinion = @"INSERT INTO MinionsVillians(MinionId, VillianId)
                                                                    VALUES
                                                                    (@MinionId, @VillianId)";

                #endregion

                try
                {
                    //one method must do only one operation! In my methods each of them has two operations, that's why ought to refactor them
                    CheckTownAndAddIt(minion, connection, getTownNameQuery, insertTownQuery, transaction);//refactor
                    int minionId = CheckMinionAndAddIt(minion, connection, getTownIdQuery, getMinionNameAndAge, insertMinionQuery, transaction);//refactor
                    int villianId = CheckVillianAndAddIt(villian, connection, checkVillian, insertVillian, transaction);//refactor
                    AddMinionToVillian(minion, villian, connection, insertConnectionBetweenVillianAndMinion, minionId, villianId, transaction);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Duplicate keys in the MinionsVillians is not allowed or you've exceed the limit of the types check the db!");
                    transaction.Rollback();
                    Console.WriteLine("Raised error : Rollback activated !!");
                    Console.WriteLine(e.Message); // possible error duplicate keys in minionsvillians map table !!
                }
                
            }

        }

        private static void AddMinionToVillian(string[] minion, string villian, SqlConnection connection, string insertConnectionBetweenVillianAndMinion, int minionId, int villianId, SqlTransaction transaction)
        {
            SqlCommand cmdInsertResults = new SqlCommand(insertConnectionBetweenVillianAndMinion, connection, transaction);
            cmdInsertResults.Parameters.AddWithValue("@MinionId", minionId);
            cmdInsertResults.Parameters.AddWithValue("@VillianId", villianId);
            cmdInsertResults.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minion[0]} to be minion of {villian}.");
        }

        private static int CheckVillianAndAddIt(string villian, SqlConnection connection, string checkVillian, string insertVillian, SqlTransaction transaction)
        {
            SqlCommand cmdCheckVillian = new SqlCommand(checkVillian, connection, transaction);
            cmdCheckVillian.Parameters.AddWithValue("@VillianName", villian);
            int villianId = (int?)cmdCheckVillian.ExecuteScalar() ?? -1;

            if (villianId == -1)
            {
                SqlCommand cmdInsertVillian = new SqlCommand(insertVillian, connection, transaction);
                cmdInsertVillian.Parameters.AddWithValue("@VillianName", villian);
                cmdInsertVillian.ExecuteNonQuery();
                Console.WriteLine($"Villain {villian} was added to the database.");

                villianId = (int)cmdCheckVillian.ExecuteScalar();
            }

            return villianId;
        }

        private static int CheckMinionAndAddIt(string[] minion, SqlConnection connection, string getTownIdQuery, string getMinionNameAndAge, string insertMinionQuery, SqlTransaction transaction)
        {
            SqlCommand cmdMinions = new SqlCommand(getMinionNameAndAge, connection, transaction);
            cmdMinions.Parameters.AddWithValue("@Username", minion[0]);
            int minionId = (int?)cmdMinions.ExecuteScalar() ?? -1;

            if (minionId == -1)
            {
                SqlCommand cmdGetTownId = new SqlCommand(getTownIdQuery, connection, transaction);
                cmdGetTownId.Parameters.AddWithValue("@TownName", minion[2]);
                int townId = (int)cmdGetTownId.ExecuteScalar();

                SqlCommand cmdInsertMinions = new SqlCommand(insertMinionQuery, connection, transaction);
                cmdInsertMinions.Parameters.AddWithValue("@Name", minion[0]);
                cmdInsertMinions.Parameters.AddWithValue("@Age", int.Parse(minion[1]));
                cmdInsertMinions.Parameters.AddWithValue("@TownId", townId);
                cmdInsertMinions.ExecuteNonQuery();
                minionId = (int)cmdMinions.ExecuteScalar();
                Console.WriteLine($"Minion {minion[0]} successfuly added to db!");
            }

            return minionId;
        }

        private static void CheckTownAndAddIt(string[] minion, SqlConnection connection, string getTownNameQuery, string insertTownQuery, SqlTransaction transaction)
        {
            SqlCommand cmdTown = new SqlCommand(getTownNameQuery, connection, transaction);
            cmdTown.Parameters.AddWithValue("@TownName", minion[2]);
            string resultTown = cmdTown.ExecuteScalar()?.ToString();

            if (resultTown == null)
            {
                SqlCommand cmdInsertTown = new SqlCommand(insertTownQuery, connection, transaction);
                cmdInsertTown.Parameters.AddWithValue("@TownName", minion[2]);
                cmdInsertTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minion[2]} was added to the database.");
            }
        }
    }
}
