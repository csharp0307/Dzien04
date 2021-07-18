using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            panelQuiz.BringToFront();
            SetupQuiz();
        }

        private Random random = new Random(0);
        private int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        int timeLeft; // czas na rozwiązanie
        Quiz quiz1, quiz2, quiz3, quiz4;

        private void timerQuiz_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = String.Format("Pozostały czas: {0} sek.", timeLeft);
            if (timeLeft<=15)
            {
                lblTimer.ForeColor = Color.Red;
            } else if (timeLeft<=30)
            {
                lblTimer.ForeColor = Color.Yellow;
            } else
            {
                lblTimer.ForeColor = Color.Black;
            }

            if (timeLeft==0)
            {
                timerQuiz.Enabled = false;
                CheckAnswers();
            }
        }

        private void CheckAnswers()
        {
            int correctAnswers = 0;
            if (numQ1.Value == quiz1.Result) correctAnswers++;
            if (numQ2.Value == quiz2.Result) correctAnswers++;
            if (numQ3.Value == quiz3.Result) correctAnswers++;
            if (numQ4.Value == quiz4.Result) correctAnswers++;

            MessageBox.Show(String.Format("Liczba poprawnych odpowiedzi: {0}", 
                correctAnswers));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timerQuiz.Enabled)
            {
                // zakoncz quiz
                timerQuiz.Enabled = false;
                btnStart.Text = "START";
                CheckAnswers();
            }
            else
            {
                // uruchom quiz
                SetupQuiz();
                panelQuiz.Visible = false;
                timerQuiz.Enabled = true;
                btnStart.Text = "STOP";
            }
        }

        private void SetupQuiz()
        {
            // zerowanie odpowiedzi i ustawianie zakresu min/max w NumericUpDown
            numQ1.Value = 0; numQ1.Minimum = Int32.MinValue; numQ1.Maximum = Int32.MaxValue;
            numQ2.Value = 0; numQ2.Minimum = Int32.MinValue; numQ2.Maximum = Int32.MaxValue;
            numQ3.Value = 0; numQ3.Minimum = Int32.MinValue; numQ3.Maximum = Int32.MaxValue;
            numQ4.Value = 0; numQ4.Minimum = Int32.MinValue; numQ4.Maximum = Int32.MaxValue;

            quiz1 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "+");
            quiz2 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "-");
            quiz3 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "*");
            quiz4 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "/");

            lblQ1.Text = quiz1.ToString();
            lblQ2.Text = quiz2.ToString();
            lblQ3.Text = quiz3.ToString();
            lblQ4.Text = quiz4.ToString();

            timeLeft = 60;
            lblTimer.Text = String.Format("Pozostały czas: {0} sek.", timeLeft);
            lblTimer.ForeColor = Color.Black;

            btnStart.Text = "START";

        }
    }
}
