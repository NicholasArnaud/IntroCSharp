using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace FSMAssessment
{
    public enum TurnStates
    {
        INIT = 1,
        IDLE = 2,
        TURN = 3,
        ATK = 4,
        ENDTURN = 5,
        EXIT = 9000,
    }
    public partial class Form1 : Form
    {
        int potionlimit = 0;
        private bool buttonWasClicked = false;
        public static Form1 _Form1;

        public Form1()
        {
            InitializeComponent();
            _Form1 = this;
            GameManager.Instance.currentState = GameManager.Instance.fsm.Start();
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            PlayerName.Text = GameManager.Instance.Aries.Name;
            EnemyName.Text = GameManager.Instance.Doomsday.Name;
            DataManager<int>.Serialize("PotionUse", potionlimit);
            GameManager.Instance.Players.Sort((emp1,emp2) =>emp1.Speed.CompareTo(emp2.Speed));
            GameManager.Instance.Players.Reverse();
        }

        public void updateLog(string message)
        {
            TextLog.AppendText("\n" + message);
        }

        /// <summary>
        /// Enables a button press if diabled and disables a button press 
        /// if enabled when called depending on string name given
        /// </summary>
        /// <param name="buttonname"></param>
        public void ButtonEnable(string buttonname)
        {
            string value = buttonname;
            if (buttonname == AtkButton.Name)
            {
                if (AtkButton.Enabled == true)
                    AtkButton.Enabled = false;
                else
                    AtkButton.Enabled = true;
            }
            if (buttonname == PotionButton.Name)
            {
                if (PotionButton.Enabled == true)
                    PotionButton.Enabled = false;
                else
                    PotionButton.Enabled = true;
            }
        }
        /// <summary>
        /// Changes if a button was clicked 
        /// </summary>
        /// <returns></returns>
        public bool checkEndButton()
        {
            if (buttonWasClicked == true)
            {
                buttonWasClicked = false;
                return true;
            }
            else
                return false;
        }

        //Certain function is called depending on current state
        private void StateFunctions()
        {
            if (GameManager.Instance.currentState == "INIT")
            {
                GameManager.Instance.turnManager.ToStartUp();
            }
            if (GameManager.Instance.currentState == "IDLE")
            {
                GameManager.Instance.turnManager.Idle();
            }
            if(GameManager.Instance.currentState == "TURN")
            {
                GameManager.Instance.turnManager.ToChoosePlayer();
            }
            if (GameManager.Instance.currentState == "ATK")
            {
                GameManager.Instance.combat.ToEnter();
            }
            if (GameManager.Instance.currentState == "ENDTURN")
            {
                GameManager.Instance.turnManager.ToEndTurn();
                TextLog.SelectionStart = TextLog.Text.Length;
                TextLog.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Starting Up files...");
            StateFunctions();
            GameManager.Instance.fsm.ChangeState("IDLE");
        }

        private void TextLog_TextChanged(object sender, EventArgs e)
        {

        }



        private void AtkButton_Click(object sender, EventArgs e)
        {
            GameManager.Instance.fsm.ChangeState("TURN");
            StateFunctions();

            Debug.WriteLine("Started Combat state...");
            GameManager.Instance.fsm.ChangeState("ATK");
            StateFunctions();

            if (GameManager.Instance.Doomsday.Health != 0)
            {
                if (EnemyHealth.Maximum == GameManager.Instance.Doomsday.MaxHealth)
                {
                    PlayerHealth.Value = GameManager.Instance.Aries.MaxHealth;
                }
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
                PlayerHealth.Value = GameManager.Instance.Aries.Health;
            }
            else
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                PlayerHealth.Value = GameManager.Instance.Aries.Health;
                EnemyHealth.Value = (int)(((float)GameManager.Instance.Swine.Health / (float)GameManager.Instance.Swine.MaxHealth) * 100f);
            }

            GameManager.Instance.fsm.ChangeState("ENDTURN");
            StateFunctions();
        }

        private void PlayerHealth_Click(object sender, EventArgs e)
        {

        }

        private void EnemyHealth_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads data from saved xml document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            //Loads previously saved information assuming files have been already created
            Debug.WriteLine("Loading previous save...");

            GameManager.Instance.Aries = DataManager<Player>.Deserialize("AriesPlayer");
            GameManager.Instance.Doomsday = DataManager<Player>.Deserialize("DoomsdayPlayer");
            GameManager.Instance.Swine = DataManager<Player>.Deserialize("SwinePlayer");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            PlayerHealth.Value = GameManager.Instance.Aries.Health;

            //loads the information for the enemy if save was created when "Doomsday" player was still alive
            if (GameManager.Instance.Doomsday.Health != 0 && EnemyHealth.Maximum != GameManager.Instance.Swine.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Doomsday.Name;
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            }
            //loads the information for the enemy if save was created before "Swine" player was active but 
            else if (GameManager.Instance.Doomsday.Health != 0 && EnemyHealth.Maximum == GameManager.Instance.Swine.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Doomsday.Name;
                EnemyHealth.Maximum = GameManager.Instance.Doomsday.Health;
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            }
            //loads the information for the enemy if save was created when "Doomsday" player was still alive
            else if (GameManager.Instance.Swine.Health != 0 && EnemyHealth.Maximum == GameManager.Instance.Doomsday.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                EnemyHealth.Maximum = GameManager.Instance.Swine.Health;
                EnemyHealth.Value = GameManager.Instance.Swine.Health;
            }

            potionlimit = DataManager<int>.Deserialize("PotionUse");
            AtkButton.Enabled = true;
            TextLog.AppendText("Previous Save Loaded... \n");
            Debug.WriteLine("Previous Save Loaded");
        }

        /// <summary>
        /// Saves needed data into an xml format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Saves information on an xml file to be read later to be loaded
            Debug.WriteLine("Saving current progress...");

            DataManager<Player>.Serialize("DoomsdayPlayer", GameManager.Instance.Doomsday);

            DataManager<Player>.Serialize("SwinePlayer", GameManager.Instance.Swine);

            DataManager<Player>.Serialize("AriesPlayer", GameManager.Instance.Aries);

            DataManager<int>.Serialize("PotionUse", potionlimit);

            DataManager<string>.Serialize("TextLog", TextLog.Text);
        }

        /// <summary>
        /// Resets needed data as if starting a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Resets data
            DataManager<int>.Serialize("AriesPlayer", GameManager.Instance.Aries.MaxHealth);
            DataManager<int>.Serialize("DoomsdayPlayer", GameManager.Instance.Doomsday.MaxHealth);
            DataManager<int>.Serialize("SwinePlayer", GameManager.Instance.Swine.MaxHealth);
            DataManager<string>.Serialize("Textlog", TextLog.Text = "");
            DataManager<int>.Serialize("PotionUse", potionlimit = 0);


            //Loads the reseted data
            PlayerHealth.Value = GameManager.Instance.Aries.Health = DataManager<int>.Deserialize("AriesPlayer");
            EnemyHealth.Maximum = GameManager.Instance.Doomsday.MaxHealth;
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health = DataManager<int>.Deserialize("DoomsdayPlayer");
            EnemyName.Text = GameManager.Instance.Doomsday.Name;
            GameManager.Instance.Swine.Health = DataManager<int>.Deserialize("SwinePlayer");
            potionlimit = DataManager<int>.Deserialize("PotionUse");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            AtkButton.Enabled = true;
            PotionButton.Enabled = true;
            TextLog.Text = "Data has been reset...";
            Debug.WriteLine("Data has reset...");
        }

        private void Potion_Click(object sender, EventArgs e)
        {
            //restores health a limited amount of times
            if (potionlimit <= 2)
            {
                TextLog.AppendText("Player has healed and now has used " + (potionlimit + 1) + " potions. \n");
                potionlimit += 1;
                GameManager.Instance.Aries.Health = GameManager.Instance.Aries.MaxHealth;
                PlayerHealth.Value = GameManager.Instance.Aries.Health;
            }
            else
            {
                PotionButton.Enabled = false;
            }

        }
        private void EndTurn_Click(object sender, EventArgs e)
        {
            //created bool variable to check if the end turn button was pressed
            buttonWasClicked = true;
            //enters combat turn for the enemy
            GameManager.Instance.combat.ToEnter();
            //enters the end turn state
            GameManager.Instance.fsm.ChangeState("ENDTURN");

            //Runs public function that sets the "buttonWasClicked" to false
            checkEndButton();

            //Checks for enemy death and if so then a new enemy will be added
            if (GameManager.Instance.Doomsday.Health != 0)
            {
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
                PlayerHealth.Value = GameManager.Instance.Aries.Health;
            }
            else
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                EnemyHealth.Value = (int)(((float)GameManager.Instance.Swine.Health / (float)GameManager.Instance.Swine.MaxHealth) * 100f);
            }
            //Moves to the next state
            StateFunctions();
        }

        //player nametags
        private void PlayerName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EnemyName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}