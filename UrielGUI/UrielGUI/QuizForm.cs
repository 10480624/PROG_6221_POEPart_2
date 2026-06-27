using System;
using System.Drawing;
using System.Windows.Forms;

namespace UrielGUI
{
    public class QuizForm : Form
    {
        private QuizManager _quiz;
        private Label lblQuestion;
        private Button[] btnAnswers;
        private Label lblFeedback;
        private Button btnNext;
        private int _selectedIndex = -1;

        public QuizForm()
        {
            _quiz = new QuizManager();
            BuildUI();
            ShowQuestion();
        }

        private void BuildUI()
        {
            this.Text = "Cybersecurity Quiz";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblQuestion = new Label
            {
                Location = new Point(20, 20),
                Size = new Size(440, 60),
                Text = "",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White
            };

            btnAnswers = new Button[4];
            for (int i = 0; i < 4; i++)
            {
                btnAnswers[i] = new Button
                {
                    Location = new Point(20, 90 + i * 45),
                    Size = new Size(440, 35),
                    Text = "",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(60, 60, 60),
                    ForeColor = Color.White,
                    Tag = i,
                    Enabled = true
                };
                btnAnswers[i].Click += AnswerButton_Click;
                this.Controls.Add(btnAnswers[i]);
            }

            lblFeedback = new Label
            {
                Location = new Point(20, 270),
                Size = new Size(440, 60),
                Text = "",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.LightGray
            };

            btnNext = new Button
            {
                Location = new Point(380, 330),
                Size = new Size(80, 30),
                Text = "Next",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                Enabled = false
            };
            btnNext.Click += BtnNext_Click;

            this.Controls.Add(lblQuestion);
            this.Controls.Add(lblFeedback);
            this.Controls.Add(btnNext);
        }

        private void ShowQuestion()
        {
            if (!_quiz.HasMoreQuestions)
            {
                lblQuestion.Text = "Quiz Complete!";
                lblFeedback.Text = _quiz.GetFinalScore();
                btnNext.Text = "Close";
                btnNext.Enabled = true;
                foreach (var btn in btnAnswers) btn.Enabled = false;
                return;
            }

            var q = _quiz.GetCurrentQuestion();
            lblQuestion.Text = q.Question;

            for (int i = 0; i < btnAnswers.Length; i++)
            {
                if (i < q.Answers.Length)
                {
                    btnAnswers[i].Text = q.Answers[i];
                    btnAnswers[i].Visible = true;
                    btnAnswers[i].Enabled = true;
                }
                else
                {
                    btnAnswers[i].Visible = false;
                }
            }

            lblFeedback.Text = "";
            _selectedIndex = -1;
            btnNext.Enabled = false;
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null || _selectedIndex != -1) return;

            _selectedIndex = (int)btn.Tag;
            string feedback = _quiz.SubmitAnswer(_selectedIndex);
            lblFeedback.Text = feedback;

            foreach (var b in btnAnswers) b.Enabled = false;

            if (!_quiz.HasMoreQuestions)
            {
                btnNext.Text = "Close";
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (btnNext.Text == "Close")
            {
                this.Close();
                return;
            }

            foreach (var b in btnAnswers)
            {
                b.Enabled = true;
                b.BackColor = Color.FromArgb(60, 60, 60);
            }
            ShowQuestion();
        }
    }
}
