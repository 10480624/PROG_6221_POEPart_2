namespace RaphaelGUI
{
    // This class satisfies the POE generic collections requirement
    // It acts like a notebook - storing things the user tells the bot
    // and allowing the bot to recall them later in the conversation
    // Example: user says "my name is Thabo" - bot stores and recalls it
    internal class MemoryManager
    {
        // This is the generic collection storing user information
        // It uses key-value pairs - like a label and its content
        // Example: "name" -> "Thabo", "interest" -> "phishing"
        // This satisfies the POE generic collections requirement
        public Dictionary<string, string> UserMemory { get; set; }

        // Constructor runs automatically when MemoryManager is created
        // It starts with an empty collection ready to store information
        public MemoryManager()
        {
            // PSEUDOCODE:
            // INITIALISE UserMemory as a new empty collection
        }

        // This method stores a piece of information about the user
        // Key is the label (e.g. "name") value is the content (e.g. "Thabo")
        // If the key already exists it updates the value
        public void Store(string key, string value)
        {
            // PSEUDOCODE:
            // IF key already exists in UserMemory
            //     UPDATE the existing value
            // ELSE
            //     ADD the new key and value to UserMemory
        }

        // This method retrieves a stored piece of information
        // Returns empty string if nothing is stored for that key
        public string Recall(string key)
        {
            // PSEUDOCODE:
            // IF key exists in UserMemory
            //     RETURN the value stored at that key
            // ELSE
            //     RETURN empty string
            return string.Empty;
        }

        // This method checks if a piece of information has been stored
        // Used by CyberBot before trying to recall something
        public bool HasMemory(string key)
        {
            // PSEUDOCODE:
            // IF key exists in UserMemory
            //     RETURN true
            // ELSE
            //     RETURN false
            return false;
        }

        // This method returns a summary of everything stored
        // Used when user asks "what do you remember about me"
        public string GetMemorySummary()
        {
            // PSEUDOCODE:
            // IF UserMemory is empty
            //     RETURN "I don't know anything about you yet"
            // ELSE
            //     BUILD a summary string from all stored key-value pairs
            //     RETURN the summary
            return string.Empty;
        }
    }
}
