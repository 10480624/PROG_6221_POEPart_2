using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrielGUI
{
    /// <summary>
    /// NLP Simulator: Analyzes raw user input and classifies the core intent 
    /// before handing it off to the bot logic.
    /// </summary>
    public enum Intent
    {
        ViewTasks, AddTask, CompleteTask, DeleteTask,
        ViewActivityLog, ShowMoreLog, StartQuiz,
        Greeting, Introduction, NameRecall,
        Sentiment, TopicTip, Unknown
    }

    public class IntentRouter
    {
        public Intent Route(string lowerInput)
        {
            // 1. Task Routing (Highest Priority)
            bool mentionsTask = lowerInput.Contains("task");

            if (mentionsTask && (lowerInput.Contains("show") || lowerInput.Contains("view") || lowerInput.Contains("list") ||
                lowerInput.Contains("my tasks") || lowerInput.Contains("what tasks") || lowerInput.Contains("what do i need to do")))
                return Intent.ViewTasks;

            if (mentionsTask && (lowerInput.Contains("complete") || lowerInput.Contains("mark") || lowerInput.Contains("finish") ||
                lowerInput.Contains("finished") || lowerInput.Contains("done") || lowerInput.Contains("did")))
                return Intent.CompleteTask;

            if (mentionsTask && (lowerInput.Contains("delete") || lowerInput.Contains("remove") ||
                lowerInput.Contains("cancel") || lowerInput.Contains("get rid")))
                return Intent.DeleteTask;

            if (mentionsTask || lowerInput.Contains("remind me") || lowerInput.Contains("set a reminder") ||
                lowerInput.Contains("need to remember") || lowerInput.Contains("don't let me forget") || lowerInput.Contains("dont let me forget"))
                return Intent.AddTask;

            // 1.5 Activity Log Routing (checked before topic/greeting so "show log" doesn't get swallowed)
            if (lowerInput.Contains("show more"))
                return Intent.ShowMoreLog;
            if (lowerInput.Contains("show activity log") || lowerInput.Contains("activity log") || lowerInput.Contains("what have you done") || lowerInput.Contains("show log"))
                return Intent.ViewActivityLog;

            // 1.6 Quiz trigger
            if (lowerInput.Contains("start quiz") || lowerInput.Contains("take quiz") || lowerInput.Contains("do the quiz") ||
                lowerInput.Contains("play quiz") || lowerInput.Contains("do a quiz") || lowerInput.Contains("quiz me") ||
                lowerInput.Contains("test my knowledge") || lowerInput.Contains("test me"))
                return Intent.StartQuiz;

            // 2. Identity & Greetings
            if (lowerInput.Contains("my name is") || lowerInput.Contains("i'm ") || lowerInput.Contains("im ") ||
                lowerInput.Contains("i am ") || lowerInput.Contains("call me") || lowerInput.Contains("this is "))
                return Intent.Introduction;
            if (lowerInput.Contains("what is my name") || lowerInput.Contains("do you remember my name"))
                return Intent.NameRecall;
            if (lowerInput.Contains("hello") || lowerInput.Contains("hi") || lowerInput.Contains("hey") || lowerInput.Contains("bye") || lowerInput.Contains("thank"))
                return Intent.Greeting;

            // 3. Sentiment & Mood
            if (lowerInput.Contains("worried") || lowerInput.Contains("scared") || lowerInput.Contains("afraid") ||
                lowerInput.Contains("frustrated") || lowerInput.Contains("angry") || lowerInput.Contains("annoyed") ||
                lowerInput.Contains("curious") || lowerInput.Contains("wondering") || lowerInput.Contains("how does") ||
                lowerInput.Contains("great") || lowerInput.Contains("thanks") || lowerInput.Contains("awesome"))
                return Intent.Sentiment;

            // 4. Topic & Tip Requests
            if (lowerInput.Contains("sassa") || lowerInput.Contains("pension") || lowerInput.Contains("lottery") || lowerInput.Contains("prize") ||
                lowerInput.Contains("capitec") || lowerInput.Contains("fnb") || lowerInput.Contains("absa") || lowerInput.Contains("bank") ||
                lowerInput.Contains("password") || lowerInput.Contains("phishing") || lowerInput.Contains("scam") ||
                lowerInput.Contains("malware") || lowerInput.Contains("virus") || lowerInput.Contains("privacy") ||
                lowerInput.Contains("browsing") || lowerInput.Contains("website") || lowerInput.Contains("another") || lowerInput.Contains("more") ||
                lowerInput.Contains("explain") || lowerInput.Contains("interested in"))
                return Intent.TopicTip;

            return Intent.Unknown;
        }
    }
}