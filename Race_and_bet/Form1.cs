using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race_and_bet
{
    public partial class Form1 : Form
    {
        Hound[] dogs = new Hound[4];
        Guy[] guys = new Guy[3];

        public Form1()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {
            label2.Text = "Minimum Bet " + numericUpDown1;

            int StartingPoint = pictureBox2.Right - pictureBox1.Right;
            int TrackLenght = pictureBox1.Size.Width;

            dogs[0] = new Hound()
            {
                MyPictureBox = pictureBox2,
                RaceTrackLenght = TrackLenght,
                StartingPosition = StartingPoint
            };

            dogs[1] = new Hound()
            {
                MyPictureBox = pictureBox3,
                RaceTrackLenght = TrackLenght,
                StartingPosition = StartingPoint
            };

            dogs[2] = new Hound()
            {
                MyPictureBox = pictureBox4,
                RaceTrackLenght = TrackLenght,
                StartingPosition = StartingPoint
            };

            dogs[3] = new Hound()
            {
                MyPictureBox = pictureBox5,
                RaceTrackLenght = TrackLenght,
                StartingPosition = StartingPoint
            };

            guys[0] = new Guy( "Joe", null, 50, radioButton1, textBox1);
            guys[1] = new Guy("Bob", null, 75, radioButton2, textBox2);
            guys[2] = new Guy("John", null, 5, radioButton3, textBox3);

            foreach( Guy guy in guys)
            {
                guy.UpdateLabels();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int WinningDog;
            button1.Enabled = false;

            while (NoWinner)
            {
                Application.DoEvents();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int GuyNumber = 0;

            if(radioButton1.Checked)
            {
                GuyNumber = 0;
            }

            if(radioButton2.Checked)
            {
                GuyNumber = 1;
            }

            if(radioButton3.Checked)
            {
                GuyNumber = 2;
            }

            guys[GuyNumber].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            guys[GuyNumber].UpdateLabels();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorName("Joe");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorName("Bob");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetBettorName("John");
        }

        private void SetBettorName(string Name)
        {
            label4.Text = Name;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i< 3; i++)
            {
                if (dogs[i] != null)
                {
                    dogs[i].Run();
                }

            }
        }
    }
}
