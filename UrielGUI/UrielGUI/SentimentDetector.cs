using System;

namespace UrielGUI
{
    public class SentimentDetector
    {
        public delegate string SentimentHandler(string sentiment);
        private SentimentHandler _handler;

        public SentimentDetector()
        {
            _handler = ProcessSentiment;
        }

        public string Detect(string input)
        {
            input = input.ToLower();
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
                return _handler("worried");
            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
                return _handler("frustrated");
            if (input.Contains("curious") || input.Contains("wondering") || input.Contains("how does"))
                return _handler("curious");
            if (input.Contains("great") || input.Contains("thanks") || input.Contains("awesome"))
                return _handler("positive");
            return null;
        }

        private string ProcessSentiment(string sentiment)
        {
            return sentiment switch
            {
                "worried" => "It's completely understandable to feel worried. Let me help reassure you.",
                "frustrated" => "I understand your frustration. Let's work through this together.",
                "curious" => "Great question! Curiosity is the first step to staying safe online.",
                "positive" => "Glad to hear it! Staying informed is the best defence.",
                _ => null
            };
        }
    }
}
