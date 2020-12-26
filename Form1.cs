using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuizTutorial
{
    
    public partial class Form1 : Form
    {
        // Instantiating a random object called randomizer
        // to generate random numbers.
        Random randomizer = new Random();

        // Two integers that store the values for the numbers.
        int addend1;
        int addend2;

        // This integer variable keeps track
        // of the remaining time left.
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer.
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problems.
            // Generate two random numbers to add.
            // Store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generate numbers 
            // into strings so that they can be displayed
            // in the label controls.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // 'sum' is the name of the NumericUpDDown control.
            // This step makes sure its value is zero before
            // adding any values to it.
            sum.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer returns true, then the user
                // got the answer right. Stop the timer and
                // show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting down.
                // Decrease the time left by one second and display
                // the new time left by updating the TimeLeft label.
                timeLeft--;
                timeLabel.Text = $"{timeLeft} seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time. ", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }
    }
}
