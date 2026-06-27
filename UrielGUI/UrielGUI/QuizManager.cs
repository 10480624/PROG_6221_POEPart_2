using System;
using System.Collections.Generic;

namespace UrielGUI
{
    public class QuizManager
    {
        private readonly List<QuizQuestion> _questions;
        private int _currentIndex;
        private int _score;

        public QuizManager()
        {
            _questions = new List<QuizQuestion>
            {
                new QuizQuestion(
                    "What is the safest way to create a password?",
                    new[] { "Use your birthday", "Use a mix of letters, numbers, and symbols", "Use 'password123'", "Use the same password everywhere" },
                    1
                ),
                new QuizQuestion(
                    "What should you do if you receive an email asking for your bank PIN?",
                    new[] { "Reply with your PIN", "Call the number in the email", "Ignore and delete it - it's a scam", "Forward it to your friends" },
                    2
                ),
                new QuizQuestion(
                    "Which of these is a sign of a phishing attempt?",
                    new[] { "A personalised greeting with your name", "Urgent language demanding immediate action", "A professional email signature", "An attachment you were expecting" },
                    1
                ),
                new QuizQuestion(
                    "What does 'multi-factor authentication' add to your account?",
                    new[] { "A second password", "An extra layer of security beyond just a password", "A backup of your data", "Automatic password changes" },
                    1
                ),
                new QuizQuestion(
                    "How often should you update your software?",
                    new[] { "Only when it crashes", "Once a year", "As soon as updates are available", "Never, updates are unnecessary" },
                    2
                ),
                new QuizQuestion(
                    "True or False: Public Wi-Fi is safe to use for online banking without any extra protection.",
                    new[] { "True", "False" },
                    1
                ),
                new QuizQuestion(
                    "What is the best way to secure your smartphone?",
                    new[] { "Install apps from unknown sources", "Use a screen lock and keep the OS updated", "Turn off all security features for speed", "Never use a password" },
                    1
                ),
                new QuizQuestion(
                    "What should you do if you think you've clicked on a malicious link?",
                    new[] { "Ignore it", "Change your passwords and run a virus scan", "Send an email to the sender", "Turn off your computer" },
                    1
                ),
                new QuizQuestion(
                    "Which of the following is a strong password example?",
                    new[] { "Password123", "MyDogFluffy", "G7#kLp!2qR$", "qwerty" },
                    2
                ),
                new QuizQuestion(
                    "What is 'social engineering' in cybersecurity?",
                    new[] { "A technical hack of computer systems", "Manipulating people into revealing confidential information", "A type of antivirus software", "A coding technique" },
                    1
                ),
                new QuizQuestion(
                    "True or False: You should use the same password for multiple accounts to remember them easily.",
                    new[] { "True", "False" },
                    1
                ),
                new QuizQuestion(
                    "What is the first step you should take if you lose your phone?",
                    new[] { "Buy a new phone", "Remote wipe your data and change passwords", "Wait for someone to return it", "Ignore it" },
                    1
                )
            };

            _currentIndex = 0;
            _score = 0;
        }

        public bool HasMoreQuestions => _currentIndex < _questions.Count;

        public QuizQuestion GetCurrentQuestion()
        {
            return _questions[_currentIndex];
        }

        public string SubmitAnswer(int selectedIndex)
        {
            var q = _questions[_currentIndex];
            bool correct = selectedIndex == q.CorrectAnswerIndex;

            if (correct) _score++;

            string feedback = correct ? "Correct!" : $"Oops. The correct answer was: {q.Answers[q.CorrectAnswerIndex]}";
            _currentIndex++;

            if (!HasMoreQuestions)
            {
                feedback += $"\n\nQuiz complete! You scored {_score} out of {_questions.Count}.";
            }

            return feedback;
        }

        public string GetFinalScore()
        {
            return $"Final score: {_score} / {_questions.Count}";
        }
    }

    public class QuizQuestion
    {
        public string Question { get; }
        public string[] Answers { get; }
        public int CorrectAnswerIndex { get; }

        public QuizQuestion(string question, string[] answers, int correctAnswerIndex)
        {
            Question = question;
            Answers = answers;
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}
