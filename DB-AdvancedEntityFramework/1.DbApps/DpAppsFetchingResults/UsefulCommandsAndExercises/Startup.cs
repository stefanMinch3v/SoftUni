namespace UsefulCommandsAndExercises
{
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using UsefulCommandsAndExercises.Properties;

    public class Startup
    {
        public static void Main()
        {
            // sql script can be use in the visual studio and then with string query = fille.readalltext(@"here drag and drop the sql script from folder which is already in the current project!")
            // sql injection : ' OR 1=1; DROP DATABASE database name
            //int employeeId = int.Parse(Console.ReadLine());
            //string townName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(Properties.Settings.Default.SoftUniDB);//new SqlConnection(@"Server=ASUS-PC\MSSQLEXPRESS2014;Database=SoftUni;Integrated Security=true");
            connection.Open();

            using (connection)
            {
                while (true)
                {
                    Console.Write("Enter command : ");
                    string command = Console.ReadLine();

                    Console.Clear();

                    switch (command)
                    {
                        case "list":
                            PrintAllProjects(connection);
                            break;
                        case "details":
                            ShowDetailsById(connection);
                            break;
                        case "search":
                            SearchByName(connection);
                            break;
                        case "exit":
                            return;
                        default:
                            break;
                    }

                }
            }





            //SearchByName(connection);
            //ShowDetailsById(connection, 2);
            //PrintAllProjects(connection);
            //Console.WriteLine(GetNumberOfEmployees(connection));
            //PrintEmployeesAndSalary(employeeId, connection);
            //AddNewCityToSoftUni(townName, connection);
            //DeleteCityFromSoftUni(townName, connection);
        }

        public static void SearchByName(SqlConnection connection)
        {
            Console.Write("Enter search criteria: ");
            string pattern = Console.ReadLine();

            string query = @"SELECT ProjectId FROM Projects WHERE Name LIKE @ProjectName";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectName", "%" + pattern + "%");

            //int result = (int?)cmd.ExecuteScalar() ?? -1; // Nullable<int> == ? //////// VERYYYYYYYYYY USEFUL
            var reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("No such project found in the db");
                return;
            }

            using (reader)
            {
                List<string> ids = new List<string>();

                while (reader.Read())
                {
                    ids.Add(reader[0].ToString());
                }

                Console.WriteLine($"Found project with ID: {string.Join(", ", ids)}");
            }
        }

        private static void ShowDetailsById(SqlConnection connection)
        {
            Console.Write("Enter project id: ");
            int projectId = int.Parse(Console.ReadLine());

            string query = @"SELECT * FROM Projects WHERE ProjectId = @ProjectId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.Read())
                {
                    Console.WriteLine("No such project found!");
                    return;
                }

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i) + ":");
                    Console.WriteLine(reader[i]);
                    Console.WriteLine("----------------------------------------");
                }
            }

            string secondQuery = @"SELECT e.EmployeeId, e.FirstName, e.LastName 
                                    FROM Employees AS e
                                    INNER JOIN EmployeesProjects AS ep
                                        ON ep.ProjectId = @ProjectId
                                        AND e.EmployeeId = ep.EmployeeId";
            SqlCommand secondCmd = new SqlCommand(secondQuery, connection);
            secondCmd.Parameters.AddWithValue("@ProjectId", projectId);
            var secondReader = secondCmd.ExecuteReader();

            Console.WriteLine("Assigned Employees: ");
            if (!secondReader.HasRows)
            {
                Console.WriteLine("No employees");
            }
            else
            {
                using (secondReader)
                {
                    while (secondReader.Read())
                    {
                        Console.WriteLine($"{secondReader[0],4}| {secondReader[1]} {secondReader[2]}");
                    }
                }
            }

            Console.WriteLine("----------------------------------------");
        }

        private static void PrintAllProjects(SqlConnection connection)
        {

            string query = @"SELECT ProjectID, Name  FROM Projects";
            SqlCommand cmd = new SqlCommand(query, connection);
            var reader = cmd.ExecuteReader();

            Console.WriteLine("ID   | Project Name");
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0],4} | {reader[1],4}");
                }
            }

        }

        private static void DeleteCityFromSoftUni(string townName, SqlConnection connection)
        {
            using (connection)
            {
                string query = $@"DELETE FROM Towns WHERE Name = '{townName}'"; // incorrect use paramethers for prevent sql injection as below in the add method
                SqlCommand cmd = new SqlCommand(query, connection);
                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Affected rows: {affectedRows}");
            }
        }

        private static void AddNewCityToSoftUni(string townName, SqlConnection connection)
        {
            using (connection)
            {
                string query = $@"INSERT INTO Towns(Name) VALUES (@TownName)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TownName", townName);

                int affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"Affected rows: {affectedRows}");
            }
        }

        private static void PrintEmployeesAndSalary(int employeeId, SqlConnection connection)
        {
            using (connection)
            {
                string query = $@"SELECT EmployeeID, FirstName, LastName, Salary FROM Employees WHERE EmployeeID = {employeeId}";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    //Console.WriteLine(reader.GetName(0)); GetName get the column name of the table 
                    //Console.WriteLine(reader.FieldCount);// count the elements in the reader array for example they are 3 because i have already selected EmplID, firstname and lastname
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-15}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("------------------------------------------------------");

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i],-15}");
                        }

                        Console.WriteLine();
                        //string firstName = reader[1].ToString();
                        //string lastName = reader[2].ToString();
                        //int employeeId = (int)reader[0]; //  as int? ?? -1 : if its null return -1 else return employeeid
                        //Console.WriteLine("{0}. {1} {2}", employeeId, firstName, lastName);
                    }
                }
            }
        }

        private static int GetNumberOfEmployees(SqlConnection connection)
        {
            using (connection)
            {
                string query = @"SELECT COUNT(*) FROM Employees";
                SqlCommand cmd = new SqlCommand(query, connection);
                int countEmployees = (int)cmd.ExecuteScalar(); // works as execute only 1 row
                return countEmployees;
            }
        }
    }
}
