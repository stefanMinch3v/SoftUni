namespace InitialSetup
{
    using System;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            ////Create DB
            //SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            //connection.Open();

            //using (connection)
            //{
            //    string query = $@"CREATE Table MinionsDB";
            //    SqlCommand cmd = new SqlCommand(query, connection);

            //    int affectedRows = cmd.ExecuteNonQuery();
            //    Console.WriteLine($"Affected rows: {affectedRows}");
            //}

            //DDL
            //SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            //connection.Open();

            //using (connection)
            //{
            //    string createTableTowns = @"CREATE TABLE Towns
            //                                (
            //                                    TownId int IDENTITY PRIMARY KEY,
            //                                    Name varchar(50),
            //                                    Country varchar(50)
            //                                )";
            //    string createTableMinions = @"CREATE TABLE Minions
            //                                (
            //                                    MinionId int IDENTITY PRIMARY KEY,
            //                                    Name varchar(50),
            //                                    Age int,
            //                                    TownId int CONSTRAINT FK_Minions_Towns FOREIGN KEY REFERENCES Towns(TownId)
            //                                )";
            //    string createTableVillians = @"CREATE TABLE Villians
            //                                (
            //                                    VillianId int IDENTITY PRIMARY KEY,
            //                                    Name varchar(50),
            //                                    EvilnessFactor varchar(10) NOT NULL CHECK(EvilnessFactor IN('Good','Bad','Evil','Super Evil'))
            //                                )";
            //    string createVilliansMinionsManyToManyTable = @"CREATE TABLE MinionsVillians
            //                                                    (
            //                                                        MinionId int,
            //                                                        VillianId int,
            //                                                        CONSTRAINT PK_MinionIdVillianId PRIMARY KEY(MinionId, VillianId),
            //                                                        CONSTRAINT FK_MinionsVilliansMinionId_MinionsMinionId FOREIGN KEY(MinionId) REFERENCES Minions(MinionId),
            //                                                        CONSTRAINT FK_MinionsVilliansVillianId_VilliansVillianId FOREIGN KEY(VillianId) REFERENCES Villians(VillianId)
            //                                                    )";
            //    string[] createTablesCommands = new[] {createTableTowns, createTableMinions, createTableVillians, createVilliansMinionsManyToManyTable };
            //    foreach (var creation in createTablesCommands)
            //    {
            //        SqlCommand cmd = new SqlCommand(creation, connection);
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            //DML
            SqlConnection connection = new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=MinionsDB;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                string fillOutTowns = @"INSERT INTO Towns(Name, Country)
                                        VALUES
                                        ('Sofia', 'Bulgaria'),
                                        ('Aalborg', 'Denmark'),
                                        ('London', 'England'),
                                        ('Burgas', 'Bulgaria'),
                                        ('Paris', 'France')";

                string fillOutMinions = @"INSERT INTO Minions(Name, Age, TownId)
                                        VALUES
                                        ('Pesho', 18, 1),
                                        ('Gosho', 22, 2),
                                        ('Ivan', 16, 3),
                                        ('Kaloqn', 27, 4),
                                        ('Plamen', 33, 5)";

                string fillOutVillians = @"INSERT INTO Villians(Name, EvilnessFactor)
                                         VALUES
                                        ('Kiro', 'Evil'),
                                        ('Milen', 'Bad'),
                                        ('Diqn', 'Super Evil'),
                                        ('Atanas', 'Good'),
                                        ('Dimityr', 'Super Evil')";

                string fillOutMinionsVillians = @"INSERT INTO MinionsVillians(MinionId, VillianId)
                                                 VALUES
                                                (1, 1),
                                                (2, 2),
                                                (2, 3),
                                                (3, 1),
                                                (4, 5)";

                string[] fillOutTables = new string[] { fillOutTowns, fillOutMinions, fillOutVillians, fillOutMinionsVillians };
                foreach (var insertion in fillOutTables)
                {
                    SqlCommand cmd = new SqlCommand(insertion, connection);
                    Console.WriteLine($"Rows affected: {cmd.ExecuteNonQuery()}");
                }
            }
        }
    }
}
