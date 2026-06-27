using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UrielGUI
{
    /// <summary>
    /// Handles all direct communication with the MySQL "uriel_tasks" database.
    /// Other classes (e.g. CyberBot, TaskManager) should call into this class
    /// rather than writing SQL themselves.
    /// </summary>
    public static class DatabaseHelper
    {
        // TODO: replace YOUR_PASSWORD_HERE with your actual MySQL root password
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=uriel_tasks;Uid=root;Pwd=Tum!5864400;";

        /// <summary>
        /// Quick check used at startup to confirm the database is reachable.
        /// Returns true if a connection could be opened, false otherwise.
        /// </summary>
        public static bool TestConnection(out string errorMessage)
        {
            errorMessage = null;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public static int AddTask(string title, string description, DateTime? reminderDate)
        {
            const string sql = @"INSERT INTO tasks (Title, Description, ReminderDate, IsCompleted)
                                  VALUES (@title, @description, @reminderDate, false);
                                  SELECT LAST_INSERT_ID();";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description ?? string.Empty);
                cmd.Parameters.AddWithValue("@reminderDate", reminderDate ?? (object)DBNull.Value);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public static List<TaskItem> GetAllTasks()
        {
            var tasks = new List<TaskItem>();
            const string sql = "SELECT TaskId, Title, Description, ReminderDate, IsCompleted, CreatedAt FROM tasks ORDER BY CreatedAt DESC;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            TaskId = reader.GetInt32("TaskId"),
                            Title = reader.GetString("Title"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate")) ? (DateTime?)null : reader.GetDateTime("ReminderDate"),
                            IsCompleted = reader.GetBoolean("IsCompleted"),
                            CreatedAt = reader.GetDateTime("CreatedAt")
                        });
                    }
                }
            }
            return tasks;
        }

        public static bool MarkTaskCompleted(int taskId)
        {
            const string sql = "UPDATE tasks SET IsCompleted = true WHERE TaskId = @taskId;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@taskId", taskId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool DeleteTask(int taskId)
        {
            const string sql = "DELETE FROM tasks WHERE TaskId = @taskId;";

            using (var conn = new MySqlConnection(ConnectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@taskId", taskId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    /// <summary>
    /// Plain data model representing one row from the "tasks" table.
    /// </summary>
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
