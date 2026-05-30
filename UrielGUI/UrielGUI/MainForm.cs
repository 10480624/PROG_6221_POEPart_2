using System;
using System.Drawing;
using System.Windows.Forms;

namespace UrielGUI
{
    public partial class MainForm : Form
    {
        private CyberBot _bot = new CyberBot();

        public MainForm()
        {
            InitializeComponent();
            AudioHelper.PlayStartup();
            AppendMessage("RAPHAEL", "Hello! I am Raphael, your South African cybersecurity assistant.");
            AppendMessage("RAPHAEL", "You can ask me about: SASSA scams, bank fraud, password safety, or lottery scams.");
            AppendMessage("RAPHAEL", "Tell me your name, then ask anything.");
        }

        private void btnSend_Click(object sender, EventArgs e) => SendMessage();

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; SendMessage(); }
        }

        private void SendMessage()
        {
            string userInput = txtUserInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput)) return;
            AppendMessage("YOU", userInput);
            txtUserInput.Clear();
            string response = _bot.ProcessInput(userInput);
            AppendMessage("RAPHAEL", response);
            lblName.Text = "Name: " + (_bot.GetName() ?? "Unknown");
            lblMood.Text = "Mood: " + (_bot.GetMood() ?? "Neutral");
        }

        private void AppendMessage(string sender, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;
            rtbChatHistory.SelectionColor = sender == "RAPHAEL" ? Color.FromArgb(76, 175, 80) : Color.White;
            rtbChatHistory.AppendText($"[{timestamp}] {sender}: {message}\n");
            rtbChatHistory.ScrollToCaret();
        }

        // Sidebar topic buttons – each defined ONCE
        private void btnPasswords_Click(object sender, EventArgs e) => txtUserInput.Text = "Tell me about passwords";
        private void btnPhishing_Click(object sender, EventArgs e) => txtUserInput.Text = "What is phishing";
        private void btnMalware_Click(object sender, EventArgs e) => txtUserInput.Text = "Tell me about malware";
        private void btnPrivacy_Click(object sender, EventArgs e) => txtUserInput.Text = "How do I protect my privacy";
    }
}