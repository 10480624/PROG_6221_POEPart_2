using System;
using System.Collections.Generic;
using System.Linq;

namespace UrielGUI
{
    /// <summary>
    /// In-memory log of actions the bot has taken this session.
    /// Other classes call Log(...) whenever something worth recording happens.
    /// Resets when the app closes (by design - not persisted to MySQL).
    /// </summary>
    public class ActivityLogger
    {
        private readonly List<string> _entries = new List<string>();

        public void Log(string description)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            _entries.Add($"[{timestamp}] {description}");
        }

        public bool IsViewLogCommand(string lowerInput)
        {
            return lowerInput.Contains("show activity log") ||
                   lowerInput.Contains("activity log") ||
                   lowerInput.Contains("what have you done") ||
                   lowerInput.Contains("show log");
        }

        public bool IsShowMoreCommand(string lowerInput)
        {
            return lowerInput.Contains("show more");
        }

        /// <summary>
        /// Returns the most recent entries (default 5-10 per the brief),
        /// most recent first.
        /// </summary>
        public string GetRecentLog(int count = 8)
        {
            if (_entries.Count == 0)
                return "No actions recorded yet this session.";

            var recent = _entries
                .Skip(Math.Max(0, _entries.Count - count))
                .Reverse()
                .Select((entry, i) => $"{i + 1}. {entry}");

            string header = "Here's a summary of recent actions:\n";
            string footer = _entries.Count > count ? "\n\n(Say 'show more' for full history.)" : "";
            return header + string.Join("\n", recent) + footer;
        }

        public string GetFullLog()
        {
            if (_entries.Count == 0)
                return "No actions recorded yet this session.";

            var all = _entries
                .Select((entry, i) => $"{i + 1}. {entry}")
                .Reverse();

            return "Full activity history:\n" + string.Join("\n", all);
        }
    }
}
