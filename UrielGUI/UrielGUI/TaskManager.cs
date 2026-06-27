using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace UrielGUI
{
    /// <summary>
    /// Sits between CyberBot and DatabaseHelper. Detects task/reminder
    /// commands, parses simple natural-language dates, and formats
    /// chat-friendly responses.
    /// </summary>
    public class TaskManager
    {
        /// <summary>
        /// Returns true if the input looks like a task/reminder command.
        /// </summary>
        public bool IsTaskCommand(string lowerInput)
        {
            return lowerInput.Contains("add a task") ||
                   lowerInput.Contains("add task") ||
                   lowerInput.Contains("create a task") ||
                   lowerInput.Contains("remind me") ||
                   lowerInput.Contains("set a reminder");
        }

        public bool IsViewTasksCommand(string lowerInput)
        {
            return lowerInput.Contains("show my tasks") ||
                   lowerInput.Contains("view tasks") ||
                   lowerInput.Contains("list tasks") ||
                   lowerInput.Contains("my tasks");
        }

        public bool IsCompleteTaskCommand(string lowerInput)
        {
            return lowerInput.Contains("complete task") ||
                   lowerInput.Contains("mark task") ||
                   lowerInput.Contains("finish task") ||
                   lowerInput.Contains("done with task");
        }

        public bool IsDeleteTaskCommand(string lowerInput)
        {
            return lowerInput.Contains("delete task") ||
                   lowerInput.Contains("remove task");
        }

        /// <summary>
        /// Creates a task from the raw user input, returns the chat-facing response.
        /// </summary>
        public string HandleAddTask(string rawInput)
        {
            DateTime? reminderDate = ParseDate(rawInput);
            string title = ExtractTitle(rawInput);

            if (string.IsNullOrWhiteSpace(title))
                return "I didn't catch what the task should be. Try: 'Remind me to update my password tomorrow.'";

            int newId = DatabaseHelper.AddTask(title, "", reminderDate);

            if (reminderDate.HasValue)
                return $"Task added: '{title}' (Task #{newId}). Reminder set for {reminderDate.Value:dddd, dd MMMM yyyy}.";
            else
                return $"Task added: '{title}' (Task #{newId}). No reminder set — say 'remind me' with a date if you want one.";
        }

        public string HandleViewTasks()
        {
            var tasks = DatabaseHelper.GetAllTasks();
            if (tasks.Count == 0)
                return "You have no tasks yet. Try: 'Add a task to enable 2FA.'";

            var lines = tasks.Take(10).Select(t =>
            {
                string status = t.IsCompleted ? "[Done]" : "[Pending]";
                string reminder = t.ReminderDate.HasValue ? $" — due {t.ReminderDate.Value:dd MMM yyyy}" : "";
                return $"#{t.TaskId} {status} {t.Title}{reminder}";
            });

            return "Your tasks:\n" + string.Join("\n", lines);
        }

        public string HandleCompleteTask(string rawInput)
        {
            int? id = ExtractTaskId(rawInput);

            if (id == null)
            {
                var match = FindTaskByTitle(rawInput);
                if (match == null)
                    return "Which task? Try: 'Complete task 3', or name it, e.g. 'I finished the password task'.";
                id = match.TaskId;
            }

            bool success = DatabaseHelper.MarkTaskCompleted(id.Value);
            return success
                ? $"Task #{id} marked as completed. Nice work!"
                : $"I couldn't find task #{id}.";
        }

        public string HandleDeleteTask(string rawInput)
        {
            int? id = ExtractTaskId(rawInput);

            if (id == null)
            {
                var match = FindTaskByTitle(rawInput);
                if (match == null)
                    return "Which task? Try: 'Delete task 3', or name it, e.g. 'delete the password task'.";
                id = match.TaskId;
            }

            bool success = DatabaseHelper.DeleteTask(id.Value);
            return success
                ? $"Task #{id} deleted."
                : $"I couldn't find task #{id}.";
        }

        // ---------- Helpers ----------

        private int? ExtractTaskId(string input)
        {
            // \b ensures we only match standalone numbers (e.g. "task 3"),
            // not digits embedded inside other words (e.g. the "2" in "2FA").
            Match m = Regex.Match(input, @"(?<![a-zA-Z])\b\d+\b(?![a-zA-Z])");
            return m.Success ? int.Parse(m.Value) : (int?)null;
        }

        /// <summary>
        /// Falls back to a partial-text search of task titles when the user
        /// names a task instead of giving a number, e.g. "I finished the
        /// password task" or "delete the 2fa task".
        /// Returns the best-matching pending task, or null if nothing matches
        /// well enough to act on confidently.
        /// </summary>
        private TaskItem FindTaskByTitle(string rawInput)
        {
            string lower = rawInput.ToLower();

            // Strip command words and filler so what's left is mostly the task description
            string[] stripWords = { "complete", "task", "mark", "finish", "finished", "done", "with",
                                     "delete", "remove", "cancel", "get", "rid", "of", "the", "i", "is",
                                     "a", "my", "to", "it", "that", "this" };
            string[] words = lower.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Where(w => !stripWords.Contains(w))
                                   .ToArray();

            if (words.Length == 0)
                return null;

            var tasks = DatabaseHelper.GetAllTasks();
            if (tasks.Count == 0)
                return null;

            // Score each task by how many of the remaining keywords appear in its title
            TaskItem best = null;
            int bestScore = 0;

            foreach (var task in tasks)
            {
                string titleLower = task.Title.ToLower();
                int score = words.Count(w => titleLower.Contains(w));

                if (score > bestScore)
                {
                    bestScore = score;
                    best = task;
                }
            }

            // Require at least one real keyword match - don't guess on zero overlap
            return bestScore > 0 ? best : null;
        }

        /// <summary>
        /// Pulls out the task title from phrases like:
        /// "remind me to update my password tomorrow"
        /// "add a task to enable 2fa"
        /// </summary>
        private string ExtractTitle(string rawInput)
        {
            string text = rawInput.Trim();
            string lower = text.ToLower();

            string[] leadPhrases = { "remind me to ", "add a task to ", "add task to ", "create a task to ", "add a task ", "add task ", "set a reminder to ", "set a reminder " };
            foreach (var phrase in leadPhrases)
            {
                int idx = lower.IndexOf(phrase);
                if (idx >= 0)
                {
                    text = text.Substring(idx + phrase.Length).Trim();
                    break;
                }
            }

            // Strip trailing date phrases so they don't pollute the title
            string[] datePhrases = { "tomorrow", "today", "next week", "tonight" };
            foreach (var dp in datePhrases)
            {
                text = Regex.Replace(text, dp, "", RegexOptions.IgnoreCase).Trim();
            }
            text = Regex.Replace(text, @"in \d+ days?", "", RegexOptions.IgnoreCase).Trim();
            text = text.TrimEnd('.', '!', '?', ' ', '"', '\'');
            text = text.Trim('"', '\'');

            return text;
        }

        /// <summary>
        /// Recognises a small set of common natural-language date phrases.
        /// Returns null if no date phrase is found (i.e. no reminder requested).
        /// </summary>
        private DateTime? ParseDate(string rawInput)
        {
            string lower = rawInput.ToLower();
            DateTime now = DateTime.Now.Date;

            if (lower.Contains("tomorrow"))
                return now.AddDays(1);

            if (lower.Contains("today") || lower.Contains("tonight"))
                return now;

            if (lower.Contains("next week"))
                return now.AddDays(7);

            Match daysMatch = Regex.Match(lower, @"in (\d+) days?");
            if (daysMatch.Success)
            {
                int days = int.Parse(daysMatch.Groups[1].Value);
                return now.AddDays(days);
            }

            return null;
        }
    }
}