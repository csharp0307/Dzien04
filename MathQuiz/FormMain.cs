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
            SetupQuiz();
        }

        private Random random = new Random(0);
        private int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        Quiz quiz1, quiz2, quiz3, quiz4;
        private void SetupQuiz()
        {
            quiz1 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "+");
            quiz2 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "-");
            quiz3 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "*");
            quiz4 = new Quiz(RandomNumber(-10, -1), RandomNumber(2, 20), "/");

            lblQ1.Text = quiz1.ToString();
            lblQ2.Text = quiz2.ToString();
            lblQ3.Text = quiz3.ToString();
            lblQ4.Text = quiz4.ToString();

        }
    }
}
