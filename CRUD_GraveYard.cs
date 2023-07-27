using Microsoft.Data.Sqlite;

namespace CompitiVacanze
{
    public class CRUD_GraveYard
    {
        //CRUD PER "Controllers\graveyard.db"
        private SqliteConnection connection = null;
        public int GetRowCount()
        {
            int rowCount = 0;
            connection = Connect();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM GraveYard"; // Sostituisci "TableName" con il nome della tabella di interesse.

                rowCount = Convert.ToInt32(command.ExecuteScalar());
            }

            return rowCount;
        }

        private SqliteConnection Connect()
        {
            if (connection == null)
            {
                connection = new SqliteConnection("Data Source = .\\Controllers\\graveyard.db");
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return connection;
        }

        public CRUD_GraveYard() { }
        public void Insert(int col, int row, int id, String name, String date, String type)
        {
            connection = Connect();
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO GraveYard VALUES (" +
                col + "," +
                row + "," +
                id + ",'" +
                name + "','" +
                date + "','" +
                type + "');";
            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            connection = Connect();
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE * FROM GraveYard WHERE id = " + id + ";";
        }
        public String[] SelectAll()
        {
            connection = Connect();
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM GraveYard";
            SqliteDataReader reader = cmd.ExecuteReader();
            String[] ret = new string[GetRowCount()];
            int i = 0;
            while (reader.Read())
            {
                ret[i] = reader.GetString(0) + "," + reader.GetString(1) + "," + reader.GetString(2) + "," + reader.GetString(3) + "," + reader.GetString(4) + "," + reader.GetString(5);
                i++;
            }
            connection.Close();
            return ret;
        }
    }
}
