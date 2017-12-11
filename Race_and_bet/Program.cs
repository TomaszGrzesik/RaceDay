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
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;
        public TextBox MyTextBox;

        public Guy(string Name, Bet MyBet, int Cash, RadioButton MyRadioButton, TextBox MyTextBox)
        {
            this.Name = Name;
            this.MyBet = MyBet;
            this.Cash = Cash;
            this.MyRadioButton = MyRadioButton;
            this.MyTextBox = MyTextBox;
        }

        public void UpdateLabels()
        {
            if (MyBet == null)
            {
                MyTextBox.Text = Name + " hasn't placed any bets";
            }
            else
            {
                MyRadioButton.Text = Name + " bets " + Cash + "$";
            }

        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Dog)
        {
            if (Amount <= Cash)
            {
                MyBet = new Bet(Amount, Dog, this);
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }

    }

    public class Hound
    {
        public int StartingPosition; //place where race begin 
        public int RaceTrackLenght; // lenght of race track
        public PictureBox MyPictureBox = null; // object which gonna race
        public int location = 0; // location on track
        public Random MyRandom; // class instance Random
        public bool finish;

        public bool Run()
        {
             MyRandom = new Random();

            if (MyPictureBox != null)
            {
                StartingPosition += location.Next(1, 5);
                ///location += MyRandom.Next(1, 4); // go random 1, 2, 3 or 4 points
            }
            //return (MyPictureBox.Right >= RaceTrackLenght - MyPictureBox.Width);
            return true;
        }

        public void TakeStartingPosition()
        {
            StartingPosition = 0;            
        }
    }

    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public Bet(int Amount, int Dog, Guy Bettor)
        {
            this.Amount = Amount;
            this.Dog = Dog;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = " ";
            if (Amount != 0)
            {
                description += Bettor.Name + " bets " + Amount + " at dog no. " + Dog;
            }
            else
            {
                description += Bettor.Name + " hasn't placed any bets.";
            }
            return description;

        }
        
        public int PayOut(int Winner)
        {
            if (Dog == Winner)
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
