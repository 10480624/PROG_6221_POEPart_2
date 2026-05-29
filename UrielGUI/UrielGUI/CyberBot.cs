namespace RaphaelGUI
{
    // This is the brain of the chatbot - expanded from Part 1
    // It coordinates all the helper classes and processes user input
    // It follows the same separation of concerns principle as Part 1
    // CyberBot never touches the UI directly - that is MainForms job
    internal class CyberBot
    {
        // Automatic properties carried over from Part 1
        // These satisfy the POE automatic properties requirement
        public string BotName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        // LastTopic remembers what was last discussed
        // Used for follow up questions like "tell me more"
        public string LastTopic { get; set; } = string.Empty;

        // Private helper objects - each has one specific job
        // readonly means they are set once in constructor and never changed
        private readonly ResponseManager _responseManager;
        private readonly SentimentDetector _sentimentDetector;
        private readonly MemoryManager _memoryManager;

        // Constructor creates all helper objects and sets the bot name
        public CyberBot()
        {
            // PSEUDOCODE:
            // SET BotName to "Raphael"
            // CREATE new ResponseManager
            // CREATE new SentimentDetector
            // CREATE new MemoryManager
        }

        // This method returns the opening greeting when the app starts
        // It checks memory first to personalise the message if possible
        public string Greet()
        {
            // PSEUDOCODE:
            // IF MemoryManager has stored a name
            //     RETURN "Welcome back " + stored name + "! How can I help you today?"
            // ELSE
            //     RETURN general welcome message explaining what Raphael can do
            return string.Empty;
        }

        // This is the main method - processes every message the user sends
        // It checks inputs in a specific order to ensure correct responses
        // Order matters - sentiment first then follow ups then keywords
        public string ProcessInput(string userMessage)
        {
            // PSEUDOCODE:

            // STEP 1 - VALIDATE INPUT
            // IF userMessage is empty or whitespace
            //     RETURN "Please type a message so I can help you."

            // STEP 2 - CLEAN INPUT
            // SET cleanMessage to lowercase trimmed userMessage

            // STEP 3 - CHECK FOR SENTIMENT FIRST
            // SET sentimentResponse = SentimentDetector.DetectSentiment(cleanMessage)
            // IF sentimentResponse is not empty
            //     STORE detected sentiment in MemoryManager with key "mood"
            //     RETURN sentimentResponse + follow up tip on LastTopic if available

            // STEP 4 - CHECK FOR FOLLOW UP QUESTIONS
            // IF cleanMessage contains "tell me more" or "another tip"
            //     or "explain more" or "give me more"
            //     IF LastTopic is not empty
            //         RETURN ResponseManager.GetFollowUpResponse(LastTopic)
            //     ELSE
            //         RETURN "What topic would you like to know more about?
            //                 You can ask about phishing passwords or privacy."

            // STEP 5 - CHECK FOR MEMORY REQUESTS
            // IF cleanMessage contains "what do you remember"
            //     or "what do you know about me"
            //     RETURN MemoryManager.GetMemorySummary()

            // STEP 6 - CHECK FOR NAME INTRODUCTION
            // IF cleanMessage contains "my name is"
            //     EXTRACT name from message after "my name is"
            //     STORE name in MemoryManager with key "name"
            //     SET UserName to extracted name
            //     RETURN "Nice to meet you " + name + "! How can I help you stay safe online?"

            // STEP 7 - CHECK FOR INTEREST DECLARATION
            // IF cleanMessage contains "interested in" or "i care about"
            //     EXTRACT topic from message
            //     STORE topic in MemoryManager with key "interest"
            //     RETURN "Great! I will remember that you are interested in " + topic
            //             + ". It is an important part of staying safe online."

            // STEP 8 - CHECK CYBERSECURITY KEYWORDS
            // IF cleanMessage contains "phishing" or "scam"
            //     SET LastTopic to "phishing"
            //     RETURN ResponseManager.GetRandomResponse("phishing")

            // IF cleanMessage contains "password"
            //     SET LastTopic to "password"
            //     RETURN ResponseManager.GetRandomResponse("password")

            // IF cleanMessage contains "privacy"
            //     SET LastTopic to "privacy"
            //     RETURN ResponseManager.GetRandomResponse("privacy")

            // IF cleanMessage contains "malware" or "virus"
            //     SET LastTopic to "malware"
            //     RETURN ResponseManager.GetRandomResponse("malware")

            // IF cleanMessage contains "browsing" or "safe browsing"
            //     SET LastTopic to "safe browsing"
            //     RETURN ResponseManager.GetRandomResponse("safe browsing")

            // STEP 9 - CHECK CONVERSATIONAL PROMPTS
            // IF cleanMessage contains "how are you"
            //     RETURN "I am fully operational and ready to help you stay safe online."

            // IF cleanMessage contains "purpose" or "who are you"
            //     RETURN description of Raphael and the SA cybersecurity campaign

            // IF cleanMessage contains "what can i ask" or "topics" or "help"
            //     RETURN list of all available topics with brief descriptions

            // STEP 10 - DEFAULT FALLBACK
            // RETURN "I am not sure about that. Try asking about passwords
            //         phishing privacy or safe browsing."

            return string.Empty;
        }
    }
}
