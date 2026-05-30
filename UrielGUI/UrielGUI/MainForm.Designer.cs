namespace UrielGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblTopics = new System.Windows.Forms.Label();
            this.btnPasswords = new System.Windows.Forms.Button();
            this.btnPhishing = new System.Windows.Forms.Button();
            this.btnMalware = new System.Windows.Forms.Button();
            this.btnPrivacy = new System.Windows.Forms.Button();
            this.btnClearChat = new System.Windows.Forms.Button();
            this.lblMemoryTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMood = new System.Windows.Forms.Label();

            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.panelInput = new System.Windows.Forms.Panel();
            this.tableLayoutPanelInput = new System.Windows.Forms.TableLayoutPanel();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.flowLayoutPanelSidebar.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.panelInput.SuspendLayout();
            this.tableLayoutPanelInput.SuspendLayout();
            this.SuspendLayout();

            // ========== splitContainerMain ==========
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.SplitterDistance = 180;   // sidebar width
            this.splitContainerMain.TabIndex = 0;

            // Panel1 (left) – sidebar
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelSidebar);

            // Panel2 (right) – chat area
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.splitContainerMain.Panel2.Controls.Add(this.tableLayoutPanelRight);

            // ========== FlowLayoutPanel for sidebar ==========
            this.flowLayoutPanelSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSidebar.WrapContents = false;
            this.flowLayoutPanelSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelSidebar.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.flowLayoutPanelSidebar.Controls.Add(this.lblLogo);
            this.flowLayoutPanelSidebar.Controls.Add(this.lblTopics);
            this.flowLayoutPanelSidebar.Controls.Add(this.btnPasswords);
            this.flowLayoutPanelSidebar.Controls.Add(this.btnPhishing);
            this.flowLayoutPanelSidebar.Controls.Add(this.btnMalware);
            this.flowLayoutPanelSidebar.Controls.Add(this.btnPrivacy);
            this.flowLayoutPanelSidebar.Controls.Add(this.btnClearChat);
            this.flowLayoutPanelSidebar.Controls.Add(this.lblMemoryTitle);
            this.flowLayoutPanelSidebar.Controls.Add(this.lblName);
            this.flowLayoutPanelSidebar.Controls.Add(this.lblMood);

            // ========== Sidebar controls (no Location / manual positioning) ==========
            // Logo
            this.lblLogo.AutoSize = false;
            this.lblLogo.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblLogo.Width = 155;
            this.lblLogo.Height = 80;
            this.lblLogo.Text = "╔══════════════════════════╗\r\n║        U R I E L         ║\r\n║    Cybersecurity Bot     ║\r\n║    South African Edition  ║\r\n╚══════════════════════════╝";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // Topics label
            this.lblTopics.AutoSize = true;
            this.lblTopics.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTopics.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblTopics.Margin = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.lblTopics.Text = "TOPICS";

            // Buttons – uniform size & margin
            foreach (var btn in new[] { this.btnPasswords, this.btnPhishing, this.btnMalware, this.btnPrivacy, this.btnClearChat })
            {
                btn.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
                btn.ForeColor = System.Drawing.Color.White;
                btn.Size = new System.Drawing.Size(155, 32);
                btn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
                btn.UseVisualStyleBackColor = false;
            }
            this.btnPasswords.Text = "Passwords";
            this.btnPasswords.Click += new System.EventHandler(this.btnPasswords_Click);
            this.btnPhishing.Text = "Phishing";
            this.btnPhishing.Click += new System.EventHandler(this.btnPhishing_Click);
            this.btnMalware.Text = "Malware";
            this.btnMalware.Click += new System.EventHandler(this.btnMalware_Click);
            this.btnPrivacy.Text = "Privacy";
            this.btnPrivacy.Click += new System.EventHandler(this.btnPrivacy_Click);
            this.btnClearChat.Text = "Clear Chat";
            this.btnClearChat.ForeColor = System.Drawing.Color.LightGray;
            this.btnClearChat.Click += (s, e) => this.rtbChatHistory.Clear();

            // Memory labels
            this.lblMemoryTitle.AutoSize = true;
            this.lblMemoryTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemoryTitle.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblMemoryTitle.Margin = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.lblMemoryTitle.Text = "MEMORY";

            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 2);
            this.lblName.Text = "Name: ";

            this.lblMood.AutoSize = true;
            this.lblMood.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblMood.ForeColor = System.Drawing.Color.White;
            this.lblMood.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lblMood.Text = "Mood: ";

            // ========== Right side (chat area) – unchanged, responsive ==========
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.rtbChatHistory, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.panelInput, 0, 2);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 3;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(720, 600);
            this.tableLayoutPanelRight.TabIndex = 0;

            // Title label
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblTitle.Text = "URIEL - Cybersecurity Assistant";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Chat history
            this.rtbChatHistory.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.rtbChatHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbChatHistory.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.rtbChatHistory.ForeColor = System.Drawing.Color.White;
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            // Input panel
            this.panelInput.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInput.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);

            // Input TableLayoutPanel
            this.tableLayoutPanelInput.ColumnCount = 2;
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanelInput.Controls.Add(this.txtUserInput, 0, 0);
            this.tableLayoutPanelInput.Controls.Add(this.btnSend, 1, 0);
            this.tableLayoutPanelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInput.RowCount = 1;
            this.tableLayoutPanelInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // TextBox
            this.txtUserInput.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.txtUserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txtUserInput.ForeColor = System.Drawing.Color.White;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);

            // Send button
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Assemble input panel
            this.panelInput.Controls.Add(this.tableLayoutPanelInput);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "MainForm";
            this.Text = "URIEL - Cybersecurity Assistant";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Cleanup
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.flowLayoutPanelSidebar.ResumeLayout(false);
            this.flowLayoutPanelSidebar.PerformLayout();
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.tableLayoutPanelInput.ResumeLayout(false);
            this.tableLayoutPanelInput.PerformLayout();
            this.ResumeLayout(false);
        }

        // Control declarations (including the new FlowLayoutPanel)
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTopics;
        private System.Windows.Forms.Button btnPasswords;
        private System.Windows.Forms.Button btnPhishing;
        private System.Windows.Forms.Button btnMalware;
        private System.Windows.Forms.Button btnPrivacy;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.Label lblMemoryTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInput;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
    }
}