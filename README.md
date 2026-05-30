PROG_6221_POEPart_2
POE Continued
URIEL – Cybersecurity Awareness Chatbot (Part 2)

South African edition – WinForms | .NET 8.0 | C#

---

Project Overview

URIEL is a cybersecurity awareness chatbot tailored for older South Africans. It features:

- WinForms GUI with dark theme, responsive layout
- Keyword recognition (passwords, phishing, malware, privacy, SASSA, lottery)
- Random responses using `List<string>` and `Random`
- Sentiment detection (worried, frustrated, curious, positive) using a delegate
- Memory storage (`Dictionary<string, string>`) for user name and mood
- Conversation flow – “another tip” continues last topic
- Input validation and fallback messages
- ASCII logo in sidebar
- Fully responsive layout (no hardcoded positions)

---

Requirements Checklist

| Requirement | Status |
|-------------|--------|
| WinForms GUI | ✅ |
| ASCII art displayed | ✅ |
| Keyword recognition (≥3 topics) | ✅ |
| Random responses | ✅ |
| Generic collections (`Dictionary`, `List`) | ✅ |
| Delegate (`SentimentHandler`) | ✅ |
| Memory (name, mood) | ✅ |
| Sentiment detection | ✅ |
| Input validation + fallback | ✅ |
| Conversation flow (“another tip”) | ✅ |
| GitHub ≥6 commits + release v2.0 | ✅ |
| Video demo | ✅ |

---

How to Run

1. Open the solution in Visual Studio 2022.
2. Ensure target framework is .NET 8.0.
3. Build (`Ctrl+Shift+B`).
4. Run (`F5`).

---

Key Technical Features

Generic Collections
- `Dictionary<string, List<string>>` in `ResponseManager.cs` stores multiple responses per topic.
- `Dictionary<string, string>` in `MemoryManager.cs` stores user name and mood.

Delegate
- `SentimentHandler` delegate in `SentimentDetector.cs` decouples sentiment detection from response generation.

Memory Persistence
- User's name and mood are stored and recalled during the session.

Responsive Layout
- `FlowLayoutPanel` in sidebar ensures consistent spacing.
- `SplitContainer` with `SplitterDistance = 180` gives chat area maximum width.
- Layout fix applied in `MainForm.cs` to override Visual Studio designer bugs.

---

File Structure
UrielGUI/
├── Program.cs
├── MainForm.cs
├── MainForm.Designer.cs
├── CyberBot.cs
├── MemoryManager.cs
├── ResponseManager.cs
├── SentimentDetector.cs
├── AudioHelper.cs
└── README.md

text

---

Video Demo

[Link to your unlisted YouTube video]

---

GitHub Release

Tag: `v2.0`  
Title: `Part 2 Submission`

---

Acknowledgments

Built for PROG6221 – Programming 2A.  
Inspired by real-world cybersecurity threats targeting South African citizens.
