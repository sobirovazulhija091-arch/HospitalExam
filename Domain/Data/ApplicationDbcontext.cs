using Npgsql;
public class ApplicationDbcontext
{
     public string connString="Host=localhost;Port=5432;Database=examd;Username=portgres;Password=1234";
     public NpgsqlConnection Connaction()=> new NpgsqlConnection(connString);
}