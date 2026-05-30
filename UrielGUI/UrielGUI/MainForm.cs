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
            // AudioHelper.PlayStartup(); // Uncomment when you have greeting.wav
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.SplitterDistance = 240;
            // Placeholder text behaviour
            txtUserInput.Text = "Ask me about cybersecurity...";
            txtUserInput.ForeColor = Color.Gray;
            txtUserInput.GotFocus += (s, e) =>
            {
                if (txtUserInput.Text == "Ask me about cybersecurity...")
                {
                    txtUserInput.Text = "";
                    txtUserInput.ForeColor = Color.White;
                }
            };
            txtUserInput.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtUserInput.Text))
                {
                    txtUserInput.Text = "Ask me about cybersecurity...";
                    txtUserInput.ForeColor = Color.Gray;
                }
            };

            AppendMessage("URIEL", "Hello! I am Uriel, your South African cybersecurity assistant.");
            AppendMessage("URIEL", "Ask me about: SASSA scams, bank fraud, passwords, or lottery scams.");
            AppendMessage("URIEL", "Tell me your name, then ask anything.");
        }

        private void btnSend_Click(object sender, EventArgs e) => SendMessage();

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userInput = txtUserInput.Text.Trim();
            if (userInput == "Ask me about cybersecurity...")
                userInput = "";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                AppendMessage("URIEL", "Please type a message or choose a topic.");
                return;
            }

            AppendMessage("YOU", userInput);
            txtUserInput.Clear();
            txtUserInput.Text = "Ask me about cybersecurity...";
            txtUserInput.ForeColor = Color.Gray;

            string response = _bot.ProcessInput(userInput);
            AppendMessage("URIEL", response);

            lblName.Text = "Name: " + (_bot.GetName() ?? "Unknown");
            lblMood.Text = "Mood: " + (_bot.GetMood() ?? "Neutral");

            txtUserInput.Focus();
        }

        private void AppendMessage(string sender, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.SelectionLength = 0;
            rtbChatHistory.SelectionColor = sender == "URIEL" ? Color.FromArgb(76, 175, 80) : Color.White;
            rtbChatHistory.AppendText($"[{timestamp}] {sender}: {message}\n");
            rtbChatHistory.ScrollToCaret();
        }

        // Auto‑send topic buttons
        private void btnPasswords_Click(object sender, EventArgs e)
        {
            txtUserInput.Text = "Tell me about passwords";
            SendMessage();
        }
        private void btnPhishing_Click(object sender, EventArgs e)
        {
            txtUserInput.Text = "What is phishing";
            SendMessage();
        }
        private void btnMalware_Click(object sender, EventArgs e)
        {
            txtUserInput.Text = "Tell me about malware";
            SendMessage();
        }
        private void btnPrivacy_Click(object sender, EventArgs e)
        {
            txtUserInput.Text = "How do I protect my privacy";
            SendMessage();
        }
    }
}