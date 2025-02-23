using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace AdmissionCommitteeBackend
{
    /// <summary>
    /// Блок анализа и работы с данными (Добавление студента, Получение всех абитуриентов, 
    /// Получение рейтинга абитуриентов (сортировка по баллам ЕГЭ), Поиск абитуриентов с баллами выше определенного значения)
    /// </summary>
    public class AdmissionCommitteeService
    {
        private const string ConnectionString = "Data Source=ApplicantLibrary\\Database\\ApplicantDB.db; Version=3;"; //Тут должен быть путь до базы данных с абитурентами

        // Регистрация нового пользователя
        public bool RegisterUser(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password);";
                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password); // В реальном приложении используйте хеширование пароля
                        try
                        {
                            command.ExecuteNonQuery();
                            return true;
                        }
                        catch (SQLiteException)
                        {
                            return false; // Пользователь с таким именем уже существует
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка SQLite: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return false;
            }
        }

        // Авторизация пользователя
        public bool LoginUser(string username, string password)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // Добавление абитуриента
        public void AddApplicant(Applicant applicant)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = @"
                    INSERT INTO Applicants (FullName, Email, Phone, ExamScore, Documents, Benefits)
                    VALUES (@FullName, @Email, @Phone, @ExamScore, @Documents, @Benefits);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FullName", applicant.FullName);
                    command.Parameters.AddWithValue("@Email", applicant.Email);
                    command.Parameters.AddWithValue("@Phone", applicant.Phone);
                    command.Parameters.AddWithValue("@ExamScore", applicant.ExamScore);
                    command.Parameters.AddWithValue("@Benefits", applicant.Benefits);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Получение всех абитуриентов
        public List<Applicant> GetAllApplicants()
        {
            var applicants = new List<Applicant>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Applicants;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        applicants.Add(new Applicant
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            ExamScore = reader.GetInt32(4),
                            Benefits = reader.GetString(6)
                        });
                    }
                }
            }
            return applicants;
        }

        // Получение рейтинга абитуриентов (сортировка по баллам ЕГЭ)
        public List<Applicant> GetApplicantsRanking()
        {
            var applicants = GetAllApplicants();
            return applicants.OrderByDescending(a => a.ExamScore).ToList();
        }

        // Расчет среднего балла всех абитуриентов
        public double GetAverageExamScore()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string avgQuery = "SELECT AVG(ExamScore) FROM Applicants;";
                using (var command = new SQLiteCommand(avgQuery, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
        }

        // Поиск абитуриентов с баллами выше определенного значения
        public List<Applicant> GetApplicantsAboveScore(int threshold)
        {
            var applicants = new List<Applicant>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Applicants WHERE ExamScore > @Threshold;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Threshold", threshold);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicants.Add(new Applicant
                            {
                                Id = reader.GetInt32(0),
                                FullName = reader.GetString(1),
                                Email = reader.GetString(2),
                                Phone = reader.GetString(3),
                                ExamScore = reader.GetInt32(4),
                                Benefits = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return applicants;
        }
    }
}
