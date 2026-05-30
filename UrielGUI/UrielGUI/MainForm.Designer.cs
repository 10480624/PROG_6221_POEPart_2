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
            this.lblTopics = new System.Windows.Forms.Label();
            this.btnPasswords = new System.Windows.Forms.Button();
            this.btnPhishing = new System.Windows.Forms.Button();
            this.btnMalware = new System.Windows.Forms.Button();
            this.btnPrivacy = new System.Windows.Forms.Button();
            this.lblMemoryTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMood = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.SplitterDistance = 250;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.splitContainerMain.Panel1.Controls.Add(this.lblTopics);
            this.splitContainerMain.Panel1.Controls.Add(this.btnPasswords);
            this.splitContainerMain.Panel1.Controls.Add(this.btnPhishing);
            this.splitContainerMain.Panel1.Controls.Add(this.btnMalware);
            this.splitContainerMain.Panel1.Controls.Add(this.btnPrivacy);
            this.splitContainerMain.Panel1.Controls.Add(this.lblMemoryTitle);
            this.splitContainerMain.Panel1.Controls.Add(this.lblName);
            this.splitContainerMain.Panel1.Controls.Add(this.lblMood);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.splitContainerMain.Panel2.Controls.Add(this.lblTitle);
            this.splitContainerMain.Panel2.Controls.Add(this.rtbChatHistory);
            this.splitContainerMain.Panel2.Controls.Add(this.txtUserInput);
            this.splitContainerMain.Panel2.Controls.Add(this.btnSend);
            // 
            // lblTopics
            // 
            this.lblTopics.AutoSize = true;
            this.lblTopics.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblTopics.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblTopics.Location = new System.Drawing.Point(20, 20);
            this.lblTopics.Name = "lblTopics";
            this.lblTopics.Size = new System.Drawing.Size(55, 18);
            this.lblTopics.TabIndex = 0;
            this.lblTopics.Text = "TOPICS";
            // 
            // btnPasswords
            // 
            this.btnPasswords.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnPasswords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasswords.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnPasswords.ForeColor = System.Drawing.Color.White;
            this.btnPasswords.Location = new System.Drawing.Point(20, 50);
            this.btnPasswords.Name = "btnPasswords";
            this.btnPasswords.Size = new System.Drawing.Size(210, 35);
            this.btnPasswords.TabIndex = 1;
            this.btnPasswords.Text = "Passwords";
            this.btnPasswords.UseVisualStyleBackColor = false;
            this.btnPasswords.Click += new System.EventHandler(this.btnPasswords_Click);
            // 
            // btnPhishing
            // 
            this.btnPhishing.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnPhishing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhishing.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnPhishing.ForeColor = System.Drawing.Color.White;
            this.btnPhishing.Location = new System.Drawing.Point(20, 95);
            this.btnPhishing.Name = "btnPhishing";
            this.btnPhishing.Size = new System.Drawing.Size(210, 35);
            this.btnPhishing.TabIndex = 2;
            this.btnPhishing.Text = "Phishing";
            this.btnPhishing.UseVisualStyleBackColor = false;
            this.btnPhishing.Click += new System.EventHandler(this.btnPhishing_Click);
            // 
            // btnMalware
            // 
            this.btnMalware.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnMalware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMalware.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnMalware.ForeColor = System.Drawing.Color.White;
            this.btnMalware.Location = new System.Drawing.Point(20, 140);
            this.btnMalware.Name = "btnMalware";
            this.btnMalware.Size = new System.Drawing.Size(210, 35);
            this.btnMalware.TabIndex = 3;
            this.btnMalware.Text = "Malware";
            this.btnMalware.UseVisualStyleBackColor = false;
            this.btnMalware.Click += new System.EventHandler(this.btnMalware_Click);
            // 
            // btnPrivacy
            // 
            this.btnPrivacy.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.btnPrivacy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrivacy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.btnPrivacy.ForeColor = System.Drawing.Color.White;
            this.btnPrivacy.Location = new System.Drawing.Point(20, 185);
            this.btnPrivacy.Name = "btnPrivacy";
            this.btnPrivacy.Size = new System.Drawing.Size(210, 35);
            this.btnPrivacy.TabIndex = 4;
            this.btnPrivacy.Text = "Privacy";
            this.btnPrivacy.UseVisualStyleBackColor = false;
            this.btnPrivacy.Click += new System.EventHandler(this.btnPrivacy_Click);
            // 
            // lblMemoryTitle
            // 
            this.lblMemoryTitle.AutoSize = true;
            this.lblMemoryTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblMemoryTitle.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblMemoryTitle.Location = new System.Drawing.Point(20, 250);
            this.lblMemoryTitle.Name = "lblMemoryTitle";
            this.lblMemoryTitle.Size = new System.Drawing.Size(62, 18);
            this.lblMemoryTitle.TabIndex = 5;
            this.lblMemoryTitle.Text = "MEMORY";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(20, 280);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 17);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name: ";
            // 
            // lblMood
            // 
            this.lblMood.AutoSize = true;
            this.lblMood.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular);
            this.lblMood.ForeColor = System.Drawing.Color.White;
            this.lblMood.Location = new System.Drawing.Point(20, 310);
            this.lblMood.Name = "lblMood";
            this.lblMood.Size = new System.Drawing.Size(51, 17);
            this.lblMood.TabIndex = 7;
            this.lblMood.Text = "Mood: ";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "RAPHAEL - Cybersecurity Assistant";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbChatHistory
            // 
            this.rtbChatHistory.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.rtbChatHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbChatHistory.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.rtbChatHistory.ForeColor = System.Drawing.Color.White;
            this.rtbChatHistory.Location = new System.Drawing.Point(0, 40);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChatHistory.Size = new System.Drawing.Size(650, 460);
            this.rtbChatHistory.TabIndex = 1;
            this.rtbChatHistory.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUserInput.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            this.txtUserInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserInput.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.txtUserInput.ForeColor = System.Drawing.Color.White;
            this.txtUserInput.Location = new System.Drawing.Point(12, 520);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(500, 27);
            this.txtUserInput.TabIndex = 2;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(528, 518);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "MainForm";
            this.Text = "RAPHAEL - Cybersecurity Assistant";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label lblTopics;
        private System.Windows.Forms.Button btnPasswords;
        private System.Windows.Forms.Button btnPhishing;
        private System.Windows.Forms.Button btnMalware;
        private System.Windows.Forms.Button btnPrivacy;
        private System.Windows.Forms.Label lblMemoryTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMood;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.Button btnSend;
    }
}