using Npgsql;
using testparser.Entity;

public class DatabaseSaver
{
    private readonly string _connectionString;

    public DatabaseSaver(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void SaveSwitches(List<SwitchData> switches)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();

            foreach (var sw in switches)
            {
                string query = $"CALL prc_insert_masterman_switch(" +
                    $"'{sw.Company}', " +
                    $"'{sw.Name.Replace("'", "''")}', " +
                    $"'{sw.Url.Replace("'", "''")}', " +
                    $"{sw.Price}, " +
                    $"{(sw.PoEports.HasValue ? sw.PoEports.Value.ToString() : "NULL")}, " +
                    $"{(sw.SFPports.HasValue ? sw.SFPports.Value.ToString() : "NULL")}, " +
                    $"{(sw.UPS.HasValue ? sw.UPS.Value.ToString().ToLower() : "NULL")}, " +
                    $"{sw.controllable.ToString().ToLower()});";

                using NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
