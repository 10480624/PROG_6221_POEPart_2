using System.Collections.Generic;

namespace UrielGUI
{
    public class MemoryManager
    {
        private Dictionary<string, string> _memory = new Dictionary<string, string>();

        public void Store(string key, string value)
        {
            _memory[key.ToLower()] = value;
        }

        public string Recall(string key)
        {
            return _memory.TryGetValue(key.ToLower(), out string val) ? val : null;
        }

        public bool Has(string key) => _memory.ContainsKey(key.ToLower());
    }
}