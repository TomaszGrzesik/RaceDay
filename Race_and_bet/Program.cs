using System;
using System.Windows.Forms;

namespace Race_and_bet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Guy
    {
        public string Name; // the guy's name
        public Bet MyBet; // Intance of Bet that has his bet
        public int Cash; // amount of owned cash

        public RadioButton MyRadioButton; //My radio Button
        public Label MyLabel; //My Label

        /*public Guy(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, TextBox MyTextBox)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyTextBox = MyTextBox;
        }
        */
        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " $.";
            MyLabel.Text = MyBet.GetDescription();

        }

        public void ClearBet()
        {
            PlaceBet(0, 0);// reset my bet            
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet = new Bet() { Amount = BetAmount, Dog = DogToWin, Bettor = this };
                UpdateLabels();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();
        }

    }

    public class Hound
    {
        public int StartingPosition; //place where race begin 
        public int RaceTrackLenght; // lenght of race track
        public PictureBox MyPictureBox = null; // object which gonna race
        public int Location = 0; // location on track
        public Random Randomizer; //An instance of Random


        // Move forward 1,2,3 or 4 at random
        // Update the position of my PictureBox on the form 
        // Return true if won the race
        public bool Run()
        {
            Location += Randomizer.Next(1, 4);
            MyPictureBox.Left = StartingPosition + Location;
            MyPictureBox.Refresh();


            if (MyPictureBox.Left >= RaceTrackLenght - MyPictureBox.Width + 20)
                return true;
            else
                return false;
        }
    

        public void TakeStartingPosition()
        {
            Location = 0; // Set my location  to 0
            MyPictureBox.Left = StartingPosition; // Take myPictureBox to starting position           
        }
    }

    public class Bet
    {
        public int Amount; // The cash that was bet
        public int Dog; // The number of Dog the bet is on
        public Guy Bettor; // The goy who placed bet

        //Return string: who placed bet, how much and which dog he bet
        // If the amount = 0, no bet was placed

        public string GetDescription()
        {              
            if (Amount > 0)
            {
                return Bettor.Name + " bets " + Amount + " on #" + Dog;                
            }
            else
            {
                return Bettor.Name + " hasn't plpaced a bet";               
            }
           }
        
        //If the dog won, return bet amount. Otherwise, return a negative bet amount
        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;
            } 
            else
            {
                return -Amount;
            }

        }
    }
}
