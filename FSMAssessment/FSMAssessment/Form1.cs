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
            GameManager.Instance.Players.Sort((emp1, emp2) => emp1.Speed.CompareTo(emp2.Speed));
            GameManager.Instance.Players.Reverse();
        }

        /// <summary>
        /// Displays about the game
        /// </summary>
        public void HelpText()
        {
            UpdateLog("Welcome to Brightest Dungeon!");
            UpdateLog("This is much simplier than Darkest Dungeon...");
            UpdateLog("HOW TO PLAY:");
            UpdateLog("You are the player on the left and your enemy is on the right.");
            UpdateLog("To Attack your enemy, just press the attack button in the center.");
            UpdateLog("You can also choose to pass your turn and not attack.");
            UpdateLog("To heal your currrent player, just press the potion button to heal");
            UpdateLog("To save or load the game, you can press the 2 buttom buttons on the far left and right.");
            UpdateLog("Or you can restart your current game by pressing the reset button.");
        }

        /// <summary>
        /// Enables the ability to add a message on the rich text document anywhere in the project
        /// </summary>
        /// <param name="message"></param>
        public void UpdateLog(string message)
        {
            TextLog.AppendText("\n" + message);
        }

        /// <summary>
        /// Enables a button press if diabled and disables a button press 
        /// if enabled when called depending on string name given
        /// </summary>
        /// <param name="buttonname"></param>
        public void ButtonEnable(string buttonname, string active)
        {
            string value = buttonname;
            if (buttonname == AtkButton.Name)
            {
                if (active == "Disable")
                    AtkButton.Enabled = false;
                else
                    AtkButton.Enabled = true;
            }
            if (buttonname == PotionButton.Name)
            {
                if (active == "Disable")
                    PotionButton.Enabled = false;
                else
                    PotionButton.Enabled = true;
            }
        }

        /// <summary>
        /// Changes if a button was clicked 
        /// </summary>
        /// <returns></returns>
        public bool CheckEndButton()
        {
            if (buttonWasClicked == true)
            {
                buttonWasClicked = false;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Enables to sync the heath bars of players anywhere else in the project
        /// </summary>
        /// <param name="player"></param>
        /// <param name="healthbarname"></param>
        public void UpdateHealthBar(Player player, string healthbarname)
        {
            if (healthbarname == EnemyHealth.Name)
                EnemyHealth.Value = player.Health;
            else if (healthbarname == PlayerHealth.Name)
                PlayerHealth.Value = player.Health;
            else
                return;
        }

        public void SetMaxHealthBar(Player player, string healthbarname)
        {
            if (healthbarname == EnemyHealth.Name)
                EnemyHealth.Maximum = player.MaxHealth;
            else if (healthbarname == PlayerHealth.Name)
                PlayerHealth.Maximum = player.MaxHealth;
            else
                return;
        }

        /// <summary>
        /// Restores a player's health a limited amount of times
        /// </summary>
        /// <param name="player"></param>
        public void PotionUse(string player)
        {
            if (PlayerName.Name == player)
            {
                if (potionlimit <= 2)
                {
                    TextLog.AppendText("Player has healed and now has used " + (potionlimit + 1) + " potions. \n");
                    potionlimit += 1;
                    GameManager.Instance.Aries.Health = GameManager.Instance.Aries.MaxHealth;
                    UpdateHealthBar(GameManager.Instance.Aries, "PlayerHealth");
                }
                else
                    PotionButton.Enabled = false;
            }
            else
                return;
        }

        /// <summary>
        /// Certain function is called depending on current state
        /// </summary>
        private void StateFunctions()
        {
            GameManager gm = GameManager.Instance;
            switch (GameManager.Instance.currentState)
            {
                case "INIT":
                    HelpText();
                    gm.turnManager.ToStartUp();
                    break;
                case "IDLE":
                    gm.turnManager.Idle();
                    break;
                case "TURN":
                    gm.turnManager.ToChoosePlayer();
                    break;
                case "ATK":
                    gm.combat.ToEnter();
                    break;
                case "ENDTURN":
                    gm.turnManager.ToEndTurn();
                    TextLog.SelectionStart = TextLog.Text.Length;
                    TextLog.ScrollToCaret();
                    break;
            }
        }

        /// <summary>
        /// Default loading function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Starting Up files...");
            StateFunctions();
            GameManager.Instance.fsm.ChangeState("IDLE");
        }

        /// <summary>
        /// Updates Battle log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextLog_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Runs attack function when pressed and continues the process of the fsm 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtkButton_Click(object sender, EventArgs e)
        {
            GameManager.Instance.fsm.ChangeState("TURN");
            StateFunctions();

            Debug.WriteLine("Started Combat state...");
            GameManager.Instance.fsm.ChangeState("ATK");
            StateFunctions();
            if (GameManager.Instance.Aries.Health != 0)
            {
                if (GameManager.Instance.Doomsday.Health != 0)
                {
                    UpdateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
                }
                else
                {
                    EnemyName.Text = GameManager.Instance.Swine.Name;
                    SetMaxHealthBar(GameManager.Instance.Swine, "EnemyHealth");
                    UpdateHealthBar(GameManager.Instance.Swine, "EnemyHealth");
                }
                UpdateHealthBar(GameManager.Instance.Aries, "PlayerHealth");
                GameManager.Instance.fsm.ChangeState("ENDTURN");
                StateFunctions();
            }
            else
            {
                PlayerName.Text = GameManager.Instance.Jingles.Name;
                SetMaxHealthBar(GameManager.Instance.Jingles, "PlayerHealth");
                if (GameManager.Instance.Doomsday.Health != 0)
                {
                    UpdateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
                }
                else
                {
                    EnemyName.Text = GameManager.Instance.Swine.Name;
                    SetMaxHealthBar(GameManager.Instance.Swine, "EnemyHealth");
                    UpdateHealthBar(GameManager.Instance.Swine, "EnemyHealth");
                }
                PlayerName.Text = GameManager.Instance.Jingles.Name;
                UpdateHealthBar(GameManager.Instance.Jingles, "PlayerHealth");
                GameManager.Instance.fsm.ChangeState("ENDTURN");
                StateFunctions();
            }
        }

        //Player and Enemy health bars
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
            GameManager.Instance.Jingles = DataManager<Player>.Deserialize("JesterPlayer");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            UpdateHealthBar(GameManager.Instance.Aries, "PlayerHealth");

            //loads the information for the enemy if save was created when "Doomsday" player was still alive
            if (GameManager.Instance.Doomsday.Health != 0 && EnemyHealth.Maximum != GameManager.Instance.Swine.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Doomsday.Name;
                UpdateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
            }
            //loads the information for the enemy if save was created when fighting "Doomsday" player but is currently fighting the "Swine" 
            else if (GameManager.Instance.Doomsday.Health != 0 && EnemyHealth.Maximum == GameManager.Instance.Swine.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Doomsday.Name;
                SetMaxHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
                UpdateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
            }
            //loads the information for the enemy if save was created when "Doomsday" player was still alive
            else if (GameManager.Instance.Swine.Health != 0 && EnemyHealth.Maximum == GameManager.Instance.Doomsday.MaxHealth)
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                SetMaxHealthBar(GameManager.Instance.Swine, "EnemyHealth");
                UpdateHealthBar(GameManager.Instance.Swine, "EnemyHealth");
            }
            //Reloads how many potions have been used and reallows the ability to attack
            potionlimit = DataManager<int>.Deserialize("PotionUse");
            AtkButton.Enabled = true;
            if (potionlimit <= 2) PotionButton.Enabled = true;

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
            DataManager<Player>.Serialize("Jester", GameManager.Instance.Jingles);

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

        /// <summary>
        /// Function that gives user full health and keeps track of how many are left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Potion_Click(object sender, EventArgs e)
        {
            PotionUse(PlayerName.Name);
        }

        /// <summary>
        /// Function that ends the user's turn without attacking 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTurn_Click(object sender, EventArgs e)
        {
            buttonWasClicked = true;
            GameManager.Instance.combat.ToEnter();
            GameManager.Instance.fsm.ChangeState("ENDTURN");

            //Checks for enemy death and if so then a new enemy will be added
            if (GameManager.Instance.Doomsday.Health != 0)
            {
                UpdateHealthBar(GameManager.Instance.Doomsday, "EnemyHealth");
                UpdateHealthBar(GameManager.Instance.Aries, "PlayerHealth");
            }
            else
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                UpdateHealthBar(GameManager.Instance.Swine, "EnemyHealth");
            }
            if (GameManager.Instance.Aries.Health == 0)
                PlayerName.Text = GameManager.Instance.Jingles.Name;
            StateFunctions();
        }

        //player nametags
        private void PlayerName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EnemyName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpText();
        }
    }
}