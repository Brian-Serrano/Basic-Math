using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Advance_Web_Programming_Project.Models.Others
{
    public static class Database
    {
        public static string GetConnectionString()
        {
            return "Data Source=LAPTOP-APKOGHND\\SQLEXPRESS;Initial Catalog=BasicMath;Integrated Security=True";
        }

        public static void SaveData(Data data, int id)
        {
            string jsonString = JsonConvert.SerializeObject(data);

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("UPDATE [Table] SET Data = @jsonData WHERE Id = @id", connection))
            {
                command.Parameters.AddWithValue("@jsonData", jsonString);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static Data LoadData(int id)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT Data FROM [Table] WHERE Id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                string jsonString = (string)command.ExecuteScalar();

                Data data = JsonConvert.DeserializeObject<Data>(jsonString);
                return data;
            }
        }

        public static bool SaveUser(string username, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("INSERT INTO [Table] (Username, Email, Password) VALUES (@username, @email, @password)", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected != 0;
            }
        }

        public static bool AuthenticateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE Username = @username AND Password = @password", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool IsUsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool IsEmailExists(string email)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [Table] WHERE Email = @email", connection))
            {
                command.Parameters.AddWithValue("@email", email);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public static int GetUserIdByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT Id FROM [Table] WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    hash.Append(b.ToString("x2"));
                }
                return hash.ToString();
            }
        }

        public static bool SetLeaderboardScore(string course, int level, int userId)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("UPDATE [Table] SET " + course + " = @level WHERE Id = @id", connection))
            {
                command.Parameters.AddWithValue("@level", level);
                command.Parameters.AddWithValue("@id", userId);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static LeaderboardUser GetLeaderboardUsers(string course, int courseId)
        {
            List<string> usernames = new List<string>();
            List<int> levels = new List<int>();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            using (SqlCommand command = new SqlCommand("SELECT TOP 20 Username, " + course + " FROM [Table] ORDER BY " + course + " DESC", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal(course)))
                        {
                            usernames.Add(reader["Username"].ToString());
                            levels.Add(Convert.ToInt32(reader[course]));
                        }
                    }
                }
            }

            return new LeaderboardUser
            {
                Username = usernames,
                Level = levels,
                Id = courseId
            };
        }
    }
}