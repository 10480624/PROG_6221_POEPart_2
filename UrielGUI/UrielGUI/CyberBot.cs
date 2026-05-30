using System;

namespace UrielGUI
{
    public class CyberBot
    {
        private ResponseManager _responses = new ResponseManager();
        private SentimentDetector _sentiment = new SentimentDetector();
        private MemoryManager _memory = new MemoryManager();
        private string _lastTopic = null;

        public string GetName() => _memory.Recall("name");
        public string GetMood() => _memory.Recall("mood");

        public string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Please type a message first.";
            if (input.Length > 300)
                return "That message is too long. Please keep it under 300 characters.";

            string lower = input.Trim().ToLower();

            // Sentiment detection with mood storage
            string sentimentResponse = _sentiment.Detect(lower);
            if (sentimentResponse != null)
            {
                if (lower.Contains("worried") || lower.Contains("scared") || lower.Contains("afraid"))
                    _memory.Store("mood", "Worried");
                else if (lower.Contains("frustrated") || lower.Contains("angry") || lower.Contains("annoyed"))
                    _memory.Store("mood", "Frustrated");
                else if (lower.Contains("curious") || lower.Contains("wondering") || lower.Contains("how does"))
                    _memory.Store("mood", "Curious");
                else if (lower.Contains("great") || lower.Contains("thanks") || lower.Contains("awesome"))
                    _memory.Store("mood", "Positive");
                return sentimentResponse;
            }

            // "another tip" conversation flow
            if ((lower.Contains("another") || lower.Contains("more") || lower.Contains("explain")) && _lastTopic != null)
                return _responses.GetResponse(_lastTopic);

            // Store user interest
            if (lower.Contains("interested in") || (lower.Contains("like") && lower.Contains("privacy")))
            {
                string topic = lower.Contains("privacy") ? "privacy" : "cybersecurity";
                _memory.Store("interest", topic);
                return $"Great! I'll remember you're interested in {topic}. Ask me anything about it.";
            }

            // Name recall
            if (lower.Contains("what is my name") || lower.Contains("do you remember my name"))
            {
                string n = _memory.Recall("name");
                return n != null ? $"Your name is {n}!" : "I don't know your name yet. Tell me!";
            }

            // Introduction - "my name is"
            if (lower.StartsWith("my name is "))
            {
                string name = input.Substring(11).Trim();
                _memory.Store("name", name);
                return $"Nice to meet you, {name}! How can I help you stay safe online?";
            }

            // Introduction - "i am" / "i'm" (improved: skip sentiment words)
            if (lower.StartsWith("i am ") || lower.StartsWith("i'm "))
            {
                string name = lower.StartsWith("i'm ") ? input.Substring(4).Trim() : input.Substring(5).Trim();
                string[] sentimentWords = { "worried", "scared", "frustrated", "angry", "curious", "fine", "okay", "not" };
                if (!Array.Exists(sentimentWords, w => name.ToLower().StartsWith(w)))
                {
                    _memory.Store("name", name);
                    return $"Hello, {name}! Ask me about passwords, scams, SASSA, or safe browsing.";
                }
            }

            // SA keyword detection (stores last topic)
            if (lower.Contains("sassa") || lower.Contains("pension")) { _lastTopic = "sassa"; return _responses.GetResponse("sassa"); }
            if (lower.Contains("lottery") || lower.Contains("prize")) { _lastTopic = "lottery"; return _responses.GetResponse("lottery"); }
            if (lower.Contains("capitec") || lower.Contains("fnb") || lower.Contains("absa") || lower.Contains("bank")) { _lastTopic = "phishing"; return _responses.GetResponse("phishing"); }
            if (lower.Contains("password")) { _lastTopic = "password"; return _responses.GetResponse("password"); }
            if (lower.Contains("phishing") || lower.Contains("scam")) { _lastTopic = "phishing"; return _responses.GetResponse("phishing"); }
            if (lower.Contains("malware") || lower.Contains("virus")) { _lastTopic = "malware"; return _responses.GetResponse("malware"); }
            if (lower.Contains("privacy")) { _lastTopic = "privacy"; return _responses.GetResponse("privacy"); }
            if (lower.Contains("browsing") || lower.Contains("website")) { _lastTopic = "browsing"; return _responses.GetResponse("browsing"); }

            // Conversational
            if (lower.Contains("hello")) return "Hello! I'm Uriel, your South African cybersecurity assistant. Ask me about bank scams, SASSA, or passwords.";
            if (lower.Contains("thank")) return "You're welcome! Stay safe, and ask a family member before clicking on links.";
            if (lower.Contains("bye")) return "Hamba kahle! Remember: no bank or SASSA will ever ask for your PIN.";

            return "I'm not sure about that. Try asking: 'bank scam', 'SASSA', 'password help', or 'another tip'.";
        }
    }
}