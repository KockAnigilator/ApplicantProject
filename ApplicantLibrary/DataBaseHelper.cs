using System.Data.SQLite;

namespace AdmissionCommitteeBackend
{
    public class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=admission.db;Version=3;"; //Тут должна быть ссылка на базу данных

        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Applicants (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        ExamScore INTEGER NOT NULL,
                        Documents TEXT,
                        Benefits TEXT
                    );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
