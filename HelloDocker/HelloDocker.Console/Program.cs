using Microsoft.Data.SqlClient;

namespace HelloDocker.Console;

public class Program
{
    private static string _connectionString;
    private static string _clientId;

    public static void Main(string[] args)
    {
        _connectionString = Environment.GetEnvironmentVariable("DB_CONN");
        _clientId = Environment.GetEnvironmentVariable("CLIENT_ID");

        System.Console.WriteLine($"DB_CONN = {_connectionString}");
        System.Console.WriteLine($"CLIENT_ID = {_clientId}");


        //if (string.IsNullOrEmpty(_connectionString))
        //    _connectionString =
        //        "Server=tcp:algo-db-server.database.windows.net,1433;Database=algo-db;User ID=algo_user;Password=$Pr0f!7@2022@!#;MultipleActiveResultSets=true;";

        //if (string.IsNullOrEmpty(_clientId)) _clientId = "A12345";

        for (int i = 0; i < 5; i++)
        {

            try
            {
                LogToDatabase(i);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            Thread.Sleep(10000);
        }
    }

    private static void LogToDatabase(int i)
    {
        using (var con = new SqlConnection(_connectionString))
        {
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO RunTest (Message, TimeStamp) VALUES (@Message, @TimeStamp)";
            cmd.Parameters.AddWithValue("@Message", $"{_clientId} run count is {i}");
            cmd.Parameters.AddWithValue("@TimeStamp", DateTime.Now);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}