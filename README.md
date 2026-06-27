PROG6221 POE — Part 3

## URIEL – Cybersecurity Awareness Chatbot
URIEL – Cybersecurity Awareness Chatbot

South African edition · WinForms · .NET 8.0 · C#

---

Project Overview

URIEL is a cybersecurity awareness chatbot with a South African focus — responses cover local context such as SASSA scams, bank phishing (Capitec/FNB/ABSA), and lottery scams, alongside general topics like passwords, malware, and privacy.

Part 3 builds directly on the Part 1 (console) and Part 2 (GUI) foundation, adding four major features:

Task Assistant — add, view, complete, and delete cybersecurity-related tasks and reminders, backed by a MySQL database
Cybersecurity Quiz — a 12-question interactive quiz (multiple-choice and true/false) with instant feedback and a final score
NLP Simulation — keyword and phrase-based intent detection that routes varied user phrasing to the correct feature
Activity Log — an in-memory record of actions taken during the session, viewable on request

---

Requirements Checklist

| Requirement | Status |
|---|---|
| WinForms GUI | ✅ |
| Keyword recognition (≥3 topics) | ✅ |
| Random responses | ✅ |
| Generic collections (`Dictionary`, `List`) | ✅ |
| Delegate (`SentimentHandler`) | ✅ |
| Memory (name, mood) | ✅ |
| Sentiment detection | ✅ |
| Input validation + fallback | ✅ |
| Conversation flow ("another tip") | ✅ |
| Task Assistant with reminders | ✅ |
| MySQL database integration (CRUD) | ✅ |
| Cybersecurity quiz (10+ questions) | ✅ |
| NLP simulation / intent routing | ✅ |
| Activity log (last 5–10 actions) | ✅ |
| GitHub ≥6 commits + tagged release | ✅ |
| Video demo | ✅ |

---

Setup Instructions

Prerequisites
- Visual Studio 2022 (or later)
- .NET 8.0 SDK
- MySQL Server 8.0+ (with MySQL Workbench recommended for inspecting the database)

1. Database setup
Run the following in MySQL Workbench (or any MySQL client) to create the database and table:

```sql
CREATE DATABASE uriel_tasks;
USE uriel_tasks;

CREATE TABLE tasks (
    TaskId INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    ReminderDate DATETIME NULL,
    IsCompleted BOOLEAN NOT NULL DEFAULT FALSE,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
```

2. Configure the connection
Open `DatabaseHelper.cs` and set your MySQL root password in the connection string:

```csharp
private const string ConnectionString =
    "Server=localhost;Port=3306;Database=uriel_tasks;Uid=root;Pwd=YOUR_PASSWORD_HERE;";
```

3. Build and run
1. Open the solution in Visual Studio.
2. Ensure the target framework is .NET 8.0.
3. Build (`Ctrl+Shift+B`) — the `MySql.Data` NuGet package will restore automatically.
4. Run (`F5`).

---

Usage Examples

Task Assistant
| You type | URIEL responds |
|---|---|
| `Add a task to enable 2FA` | Creates the task, no reminder |
| `Remind me to update my password tomorrow` | Creates the task with tomorrow's date as the reminder |
| `Show my tasks` | Lists all tasks with status and due dates |
| `Complete task 3` *or* `I finished the password task` | Marks the task as done — by number or by name |
| `Delete task 3` *or* `Delete the 2fa task` | Removes the task — by number or by name |

Cybersecurity Quiz
Type `start quiz` (or `quiz me`, `test my knowledge`) to launch a 12-question quiz in a separate window. Each question gives instant feedback; a final score is shown at the end.

Activity Log
| You type | URIEL responds |
|---|---|
| `Show activity log` *or* `What have you done?` | Lists the most recent actions (up to 10) |
| `Show more` | Lists the full session history |

General conversation (Parts 1–2, still active in Part 3)
| You type | URIEL responds |
|---|---|
| `Hi, my name is Tumi` | Greets you by name and remembers it |
| `Tell me about passwords` | Gives a password safety tip |
| `I'm worried about scams` | Responds with sentiment-aware reassurance |

---

Key Technical Features

Intent Routing (NLP Simulation)
`IntentRouter.cs` classifies user input into an `Intent` before `CyberBot.cs` decides how to respond. Detection is keyword/phrase-based using `string.Contains()` rather than requiring exact phrasing, so requests like "I finished the password task" and "complete task 3" are both recognised as the same intent.

Database Integration
`DatabaseHelper.cs` handles all MySQL communication (add, view, complete, delete) using parameterised queries. `TaskManager.cs` sits between the chatbot and the database, handling natural-language date parsing (e.g. "tomorrow", "in 3 days") and task lookup by name when no task number is given.

Activity Log
`ActivityLogger.cs` keeps an in-memory list of actions taken during the current session (by design — it resets when the app closes, per the assignment brief).

Generic Collections
- `Dictionary<string, List<string>>` in `ResponseManager.cs` stores multiple responses per topic.
- `Dictionary<string, string>` in `MemoryManager.cs` stores the user's name and mood.

Delegate
- `SentimentHandler` delegate in `SentimentDetector.cs` is used as the callback mechanism for matching detected sentiment to a response.

Memory Persistence
- The user's name and mood are stored and recalled for the duration of the session.

Responsive Layout
- `FlowLayoutPanel` in the sidebar keeps spacing consistent regardless of window size.
- `SplitContainer` divides the sidebar and chat area (`SplitterDistance = 240` at runtime).

---

File Structure

```
UrielGUI/
├── Program.cs
├── MainForm.cs
├── MainForm.Designer.cs
├── CyberBot.cs
├── IntentRouter.cs
├── TaskManager.cs
├── DatabaseHelper.cs
├── ActivityLogger.cs
├── QuizManager.cs
├── QuizForm.cs
├── MemoryManager.cs
├── ResponseManager.cs
├── SentimentDetector.cs
├── AudioHelper.cs
└── README.md
```

---

Video Demo

[Link to unlisted YouTube video]

---

GitHub Release

Tag: `v3.0`
Title: `Part 3 Submission`

---

Acknowledgments

Built for PROG6221 – Programming 2A.
Inspired by real-world cybersecurity threats facing South African internet users.
