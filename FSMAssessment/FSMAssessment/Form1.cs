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
            GameManager.Instance.currentState = GameManager.Instance.stateSystem.Start();
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
        public void PotionUse(Player player)
        {
            potionlimit += 1;
            if (PlayerName.Text == player.Name)
            {
                if (potionlimit < 3)
                {
                    player.Health = player.MaxHealth;
                    UpdateHealthBar(player, "PlayerHealth");
                }
                else
                    PotionButton.Enabled = false;
            }
            else
                return;
            TextLog.AppendText("Player has healed and now has used " + (potionlimit) + " potions. \n");
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
                    TextLog.SelectionStart = TextLog.Text.Length;
                    TextLog.ScrollToCaret();
                    break;
                case "TURN":
                    gm.turnManager.ToChoosePlayer();
                    TextLog.SelectionStart = TextLog.Text.Length;
                    TextLog.ScrollToCaret();
                    break;
                case "ATK":
                    gm.combat.ToEnter();
                    TextLog.SelectionStart = TextLog.Text.Length;
                    TextLog.ScrollToCaret();
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
            GameManager.Instance.stateSystem.ChangeState("IDLE");
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
            GameManager gm = GameManager.Instance;

            gm.stateSystem.ChangeState("TURN");
            StateFunctions();

            Debug.WriteLine("Started Combat state...");
            gm.stateSystem.ChangeState("ATK");
            StateFunctions();
            if (gm.Aries.Health != 0)
            {
                if (gm.Doomsday.Health != 0)
                {
                    UpdateHealthBar(gm.Doomsday, "EnemyHealth");
                }
                else
                {
                    EnemyName.Text = gm.Swine.Name;
                    SetMaxHealthBar(gm.Swine, "EnemyHealth");
                    UpdateHealthBar(gm.Swine, "EnemyHealth");
                }
                UpdateHealthBar(gm.Aries, "PlayerHealth");
                gm.stateSystem.ChangeState("ENDTURN");
                StateFunctions();
            }
            else
            {
                if (gm.Doomsday.Health != 0)
                {
                    UpdateHealthBar(gm.Doomsday, "EnemyHealth");
                }
                else
                {
                    EnemyName.Text = gm.Swine.Name;
                    SetMaxHealthBar(gm.Swine, "EnemyHealth");
                    UpdateHealthBar(gm.Swine, "EnemyHealth");
                }
                PlayerName.Text = gm.Jingles.Name;
                UpdateHealthBar(gm.Jingles, "PlayerHealth");
                gm.stateSystem.ChangeState("ENDTURN");
                StateFunctions();
            }
            TextLog.Text = gm.combat.combatLog;
        }
        private void EndTurn_Click(object sender, EventArgs e)
        {
            GameManager gm = GameManager.Instance;
            if (gm.Doomsday.Health != 0)
                gm.combat.PassAttack(gm.CurrentPlayer, gm.Doomsday);
            else
                gm.combat.PassAttack(gm.CurrentPlayer, gm.Swine);
            gm.stateSystem.ChangeState("ENDTURN");
            StateFunctions();
            StateFunctions();
            if (gm.Aries.Health == 0)
            {
                PlayerName.Text = gm.Jingles.Name;
                SetMaxHealthBar(gm.Jingles, "PlayerHealth");
                UpdateHealthBar(gm.Jingles, "PlayerHealth");
            }
            else
                UpdateHealthBar(gm.Aries, "PlayerHealth");


            TextLog.Text = gm.combat.combatLog;
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
            GameManager gm = GameManager.Instance;

            //Loads previously saved information assuming files have been already created
            Debug.WriteLine("Loading previous save...");
            gm.Aries = DataManager<Player>.Deserialize("AriesPlayer");
            gm.Doomsday = DataManager<Player>.Deserialize("DoomsdayPlayer");
            gm.Swine = DataManager<Player>.Deserialize("SwinePlayer");
            gm.Jingles = DataManager<Player>.Deserialize("JesterPlayer");
            gm.CurrentPlayer = DataManager<Player>.Deserialize("CurrentPlayer");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            if (gm.CurrentPlayer.Health != 0)
            {
                SetMaxHealthBar(gm.CurrentPlayer, "PlayerHealth");
                UpdateHealthBar(gm.CurrentPlayer, "PlayerHealth");
                PlayerName.Name = gm.CurrentPlayer.Name;

                //loads the information for the enemy if save was created when "Doomsday" player was still alive
                if (gm.Doomsday.Health != 0 && EnemyHealth.Maximum != gm.Swine.MaxHealth)
                {
                    EnemyName.Text = gm.Doomsday.Name;
                    UpdateHealthBar(gm.Doomsday, "EnemyHealth");
                }
                //loads the information for the enemy if save was created when fighting "Doomsday" player but is currently fighting the "Swine" 
                else if (gm.Doomsday.Health != 0 && EnemyHealth.Maximum == gm.Swine.MaxHealth)
                {
                    EnemyName.Text = gm.Doomsday.Name;
                    SetMaxHealthBar(gm.Doomsday, "EnemyHealth");
                    UpdateHealthBar(gm.Doomsday, "EnemyHealth");
                }
                //loads the information for the enemy if save was created when "Doomsday" player was still alive
                else if (gm.Swine.Health != 0 && EnemyHealth.Maximum == gm.Doomsday.MaxHealth)
                {
                    EnemyName.Text = gm.Swine.Name;
                    SetMaxHealthBar(gm.Swine, "EnemyHealth");
                    UpdateHealthBar(gm.Swine, "EnemyHealth");
                }
            }
            //else if (gm.Jingles.Health != 0)
            //{
            //    UpdateHealthBar(gm.Jingles, "PlayerHealth");
            //    //loads the information for the enemy if save was created when "Doomsday" player was still alive
            //    if (gm.Doomsday.Health != 0 && EnemyHealth.Maximum != gm.Swine.MaxHealth)
            //    {
            //        EnemyName.Text = gm.Doomsday.Name;
            //        UpdateHealthBar(gm.Doomsday, "EnemyHealth");
            //    }
            //    //loads the information for the enemy if save was created when fighting "Doomsday" player but is currently fighting the "Swine" 
            //    else if (gm.Doomsday.Health != 0 && EnemyHealth.Maximum == gm.Swine.MaxHealth)
            //    {
            //        EnemyName.Text = gm.Doomsday.Name;
            //        SetMaxHealthBar(gm.Doomsday, "EnemyHealth");
            //        UpdateHealthBar(gm.Doomsday, "EnemyHealth");
            //    }
            //    //loads the information for the enemy if save was created when "Doomsday" player was still alive
            //    else if (gm.Swine.Health != 0 && EnemyHealth.Maximum == gm.Doomsday.MaxHealth)
            //    {
            //        EnemyName.Text = gm.Swine.Name;
            //        SetMaxHealthBar(gm.Swine, "EnemyHealth");
            //        UpdateHealthBar(gm.Swine, "EnemyHealth");
            //    }
            //}
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
            GameManager gm = GameManager.Instance;

            //Saves information on an xml file to be read later to be loaded
            Debug.WriteLine("Saving current progress...");

            DataManager<Player>.Serialize("DoomsdayPlayer", gm.Doomsday);
            DataManager<Player>.Serialize("SwinePlayer", gm.Swine);
            DataManager<Player>.Serialize("AriesPlayer", gm.Aries);
            DataManager<Player>.Serialize("JesterPlayer", gm.Jingles);
            DataManager<Player>.Serialize("CurrentPlayer", gm.CurrentPlayer);

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
            GameManager gm = GameManager.Instance;

            //Resets data
            DataManager<int>.Serialize("AriesPlayer", gm.Aries.MaxHealth);
            DataManager<int>.Serialize("DoomsdayPlayer", gm.Doomsday.MaxHealth);
            DataManager<int>.Serialize("SwinePlayer", gm.Swine.MaxHealth);
            DataManager<string>.Serialize("Textlog", TextLog.Text = "");
            DataManager<int>.Serialize("PotionUse", potionlimit = 0);

            //Loads the reseted data
            PlayerHealth.Value = gm.Aries.Health = DataManager<int>.Deserialize("AriesPlayer");
            EnemyHealth.Maximum = gm.Doomsday.MaxHealth;
            EnemyHealth.Value = gm.Doomsday.Health = DataManager<int>.Deserialize("DoomsdayPlayer");
            EnemyName.Text = gm.Doomsday.Name;
            gm.Swine.Health = DataManager<int>.Deserialize("SwinePlayer");
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
            PotionUse(GameManager.Instance.CurrentPlayer);
            UpdateHealthBar(GameManager.Instance.CurrentPlayer, "PlayerHealth");
        }

        /// <summary>
        /// Function that ends the user's turn without attacking 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


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