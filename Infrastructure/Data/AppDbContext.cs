namespace Infrastructure.Data;
using Npgsql;
using System.Data;
public class AppDbContext
{
     private string connectionString = "Host=localhost;Port=5432;Database=Employees;Username=postgres;Password=0510";

    public  IDbConnection Connection()=> new NpgsqlConnection(connectionString);
}

