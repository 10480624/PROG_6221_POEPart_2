using System;

namespace UrielGUI
{
    public class CyberBot
    {
        private ResponseManager _responses = new ResponseManager();
        private SentimentDetector _sentiment = new SentimentDetector();
        private MemoryManager _memory = new MemoryManager();
        private TaskManager _tasks = new TaskManager();
        private ActivityLogger _activityLog = new ActivityLogger();
        private IntentRouter _router = new IntentRouter(); // NLP Engine

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

            // Route the input using our NLP Simulator
            Intent currentIntent = _router.Route(lower);

            // Dispatch based on detected intent
            switch (currentIntent)
            {
                case Intent.ViewTasks:
                    return _tasks.HandleViewTasks();

                case Intent.CompleteTask:
                    {
                        string result = _tasks.HandleCompleteTask(input);
                        _activityLog.Log(result);
                        return result;
                    }

                case Intent.DeleteTask:
                    {
                        string result = _tasks.HandleDeleteTask(input);
                        _activityLog.Log(result);
                        return result;
                    }

                case Intent.AddTask:
                    {
                        string result = _tasks.HandleAddTask(input);
                        _activityLog.Log(result);
                        return result;
                    }

                case Intent.ViewActivityLog:
                    return _activityLog.GetRecentLog();

                case Intent.ShowMoreLog:
                    return _activityLog.GetFullLog();

                case Intent.StartQuiz:
                    {
                        string result = HandleStartQuiz();
                        _activityLog.Log("Quiz started/completed.");
                        return result;
                    }

                case Intent.Introduction:
                    return HandleIntroduction(input, lower);
                case Intent.NameRecall:
                    string n = _memory.Recall("name");
                    return n != null ? $"Your name is {n}!" : "I don't know your name yet. Tell me!";
                case Intent.Greeting:
                    return HandleGreeting(lower);
                case Intent.Sentiment:
                    return HandleSentiment(lower);
                case Intent.TopicTip:
                    return HandleTopicTip(lower);

                case Intent.Unknown:
                default:
                    return "I'm not sure about that. Try asking: 'bank scam', 'SASSA', 'password help', 'add a task', or 'show activity log'.";
            }
        }

        private string HandleIntroduction(string input, string lower)
        {
            string name = ExtractName(input, lower);

            if (string.IsNullOrWhiteSpace(name))
                return "Hi there! What's your name?";

            // Catch edge cases where someone says "I am worried" instead of a name
            string[] sentimentWords = { "worried", "scared", "frustrated", "angry", "curious", "fine", "okay", "not" };
            if (Array.Exists(sentimentWords, w => name.ToLower().StartsWith(w)))
            {
                return HandleSentiment(lower);
            }

            _memory.Store("name", name);
            return $"Nice to meet you, {name}! How can I help you stay safe online?";
        }

        /// <summary>
        /// Finds an introduction phrase ("my name is", "i'm", "call me", etc.)
        /// anywhere in the input and extracts whatever follows it as the name.
        /// </summary>
        private string ExtractName(string input, string lower)
        {
            string[] phrases = { "my name is", "call me", "this is", "i am", "i'm", "im " };

            foreach (var phrase in phrases)
            {
                int idx = lower.IndexOf(phrase);
                if (idx >= 0)
                {
                    string afterPhrase = input.Substring(idx + phrase.Length).Trim();
                    // Take just the first word as the name (handles trailing punctuation/extra words)
                    string[] words = afterPhrase.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    if (words.Length > 0)
                        return words[0];
                }
            }
            return "";
        }

        private string HandleGreeting(string lower)
        {
            if (lower.Contains("hello")) return "Hello! I'm Uriel, your South African cybersecurity assistant. Ask me about bank scams, SASSA, or passwords.";
            if (lower.Contains("thank")) return "You're welcome! Stay safe, and ask a family member before clicking on links.";
            if (lower.Contains("bye")) return "Hamba kahle! Remember: no bank or SASSA will ever ask for your PIN.";
            return "Hello!";
        }

        private string HandleSentiment(string lower)
        {
            string sentimentResponse = _sentiment.Detect(lower);

            if (lower.Contains("worried") || lower.Contains("scared") || lower.Contains("afraid")) _memory.Store("mood", "Worried");
            else if (lower.Contains("frustrated") || lower.Contains("angry") || lower.Contains("annoyed")) _memory.Store("mood", "Frustrated");
            else if (lower.Contains("curious") || lower.Contains("wondering") || lower.Contains("how does")) _memory.Store("mood", "Curious");
            else if (lower.Contains("great") || lower.Contains("thanks") || lower.Contains("awesome")) _memory.Store("mood", "Positive");

            return sentimentResponse ?? "I understand. Let's focus on keeping you safe online.";
        }

        private string HandleTopicTip(string lower)
        {
            if (lower.Contains("interested in") || (lower.Contains("like") && lower.Contains("privacy")))
            {
                string topic = lower.Contains("privacy") ? "privacy" : "cybersecurity";
                _memory.Store("interest", topic);
                return $"Great! I'll remember you're interested in {topic}. Ask me anything about it.";
            }

            if ((lower.Contains("another") || lower.Contains("more") || lower.Contains("explain")) && _lastTopic != null)
                return _responses.GetResponse(_lastTopic);

            if (lower.Contains("sassa") || lower.Contains("pension")) { _lastTopic = "sassa"; return _responses.GetResponse("sassa"); }
            if (lower.Contains("lottery") || lower.Contains("prize")) { _lastTopic = "lottery"; return _responses.GetResponse("lottery"); }
            if (lower.Contains("capitec") || lower.Contains("fnb") || lower.Contains("absa") || lower.Contains("bank")) { _lastTopic = "phishing"; return _responses.GetResponse("phishing"); }
            if (lower.Contains("password")) { _lastTopic = "password"; return _responses.GetResponse("password"); }
            if (lower.Contains("phishing") || lower.Contains("scam")) { _lastTopic = "phishing"; return _responses.GetResponse("phishing"); }
            if (lower.Contains("malware") || lower.Contains("virus")) { _lastTopic = "malware"; return _responses.GetResponse("malware"); }
            if (lower.Contains("privacy")) { _lastTopic = "privacy"; return _responses.GetResponse("privacy"); }
            if (lower.Contains("browsing") || lower.Contains("website")) { _lastTopic = "browsing"; return _responses.GetResponse("browsing"); }

            return "I have a tip for that, but my wires got crossed!";
        }

        private string HandleStartQuiz()
        {
            // Open the QuizForm as a dialog so the user can't interact with the main window until it closes
            var quizForm = new QuizForm();
            quizForm.ShowDialog();
            return "Quiz completed! Check your score in the window.";
        }
    }
}