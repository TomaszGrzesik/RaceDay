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
        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {
            /*label2.Text = "Minimum Bet " + numericUpDown1;

            int StartingPoint = pictureBox2.Right - pictureBox1.Right;
            int TrackLenght = pictureBox1.Size.Width;
            */
            dogs[0] = new Hound()
            {
                MyPictureBox = pictureBox2,
                RaceTrackLenght = pictureBox1.Width - pictureBox2.Width,
                StartingPosition = pictureBox1.Left,
                Randomizer = MyRandomizer
            };

            dogs[1] = new Hound()
            {
                MyPictureBox = pictureBox3,
                RaceTrackLenght = pictureBox1.Width - pictureBox3.Width,
                StartingPosition = pictureBox1.Left,
                Randomizer = MyRandomizer
            };

            dogs[2] = new Hound()
            {
                MyPictureBox = pictureBox3,
                RaceTrackLenght = pictureBox1.Width - pictureBox3.Width,
                StartingPosition = pictureBox1.Left,
                Randomizer = MyRandomizer
            };

            dogs[3] = new Hound()
            {
                MyPictureBox = pictureBox4,
                RaceTrackLenght = pictureBox1.Width - pictureBox4.Width,
                StartingPosition = pictureBox1.Left,
                Randomizer = MyRandomizer
            };

            guys[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = radioButton1, MyLabel = joeBetLabel };
            //guys[0] = new Guy() { "Joe", 50, radioButton1, textBox1 };
            guys[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = radioButton2, MyLabel = bobBetLabel  };
            guys[2] = new Guy() { Name = "John", Cash = 5, MyRadioButton = radioButton3, MyLabel = johnBetLabel };

            /*foreach( Guy guy in guys)
            {
                guy.UpdateLabels();
            }*/
            label2.Text = "Minimum bet: " + numericUpDown1.Minimum + " $.";
            refreshGuyState();
        }

        public void refreshGuyState()
        {
            for (int i = 0; i < guys.Length; i++)
            {
                guys[i].ClearBet();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < dogs.Length; c++)
            {
                dogs[c].TakeStartingPosition();
            }
            //bettingGroup.Enabled = false;
            timer1.Start();
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
            int winningDog = 0;

            for (int i = 0; i< dogs.Length; i++)
            {
                if (dogs[i].Run())
                {
                    timer1.Stop();
                    winningDog = i + 1;
                    MessageBox.Show("Dog no." + winningDog + "won the race");
                }

                for (int b = 0; b <guys.Length; b++)
                {
                    guys[b].Collect(winningDog);
                }

                refreshGuyState();
                //bettingGroup.Enabled = true;
                break;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
