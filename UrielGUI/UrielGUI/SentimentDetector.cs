namespace RaphaelGUI
{
    // This class satisfies the POE delegates requirement
    // It detects the users mood or sentiment from their message
    // and adjusts the bots response to feel more natural and human
    // Example: user says "I am worried about scams"
    // bot detects worried sentiment and responds with reassurance first
    internal class SentimentDetector
    {
        // This is the delegate type - it defines a blueprint for sentiment handlers
        // Each handler takes a message and returns an appropriate response
        // This satisfies the POE delegates requirement
        public delegate string SentimentHandler(string message);

        // Each of these properties holds a handler for a specific sentiment
        // They are assigned in the constructor
        public SentimentHandler? WorriedHandler { get; set; }
        public SentimentHandler? FrustratedHandler { get; set; }
        public SentimentHandler? CuriousHandler { get; set; }
        public SentimentHandler? PositiveHandler { get; set; }

        // Constructor assigns a response method to each sentiment handler
        // This is where delegates are wired up to their logic
        public SentimentDetector()
        {
            // PSEUDOCODE:
            // ASSIGN WorriedHandler to a method that returns
            //     "It is completely understandable to feel that way.
            //      Let me share some tips to help you stay safe."

            // ASSIGN FrustratedHandler to a method that returns
            //     "I understand this can feel overwhelming.
            //      Let me break it down simply for you."

            // ASSIGN CuriousHandler to a method that returns
            //     "Great curiosity! That is the first step to staying safe online.
            //      Let me share what I know."

            // ASSIGN PositiveHandler to a method that returns
            //     "Glad to hear that! Staying informed is the best defence."
        }

        // This method checks the users message for sentiment keywords
        // Returns an appropriate response if sentiment is detected
        // Returns empty string if no sentiment is detected
        // CyberBot calls this first before checking for topics
        public string DetectSentiment(string userMessage)
        {
            // PSEUDOCODE:
            // SET message to lowercase version of userMessage

            // IF message contains "worried" or "scared" or "afraid" or "nervous"
            //     CALL WorriedHandler and RETURN result

            // IF message contains "frustrated" or "angry" or "annoyed" or "confused"
            //     CALL FrustratedHandler and RETURN result

            // IF message contains "curious" or "interested" or "want to know" or "wondering"
            //     CALL CuriousHandler and RETURN result

            // IF message contains "great" or "thanks" or "helpful" or "awesome"
            //     CALL PositiveHandler and RETURN result

            // IF no sentiment detected
            //     RETURN empty string so normal response system takes over
            return string.Empty;
        }
    }
}
