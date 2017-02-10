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
        ATK = 3,
        ENDTURN = 5,
        EXIT = 9000,
    }
    public partial class Form1 : Form
    {
        int limit = 0;

        public Form1()
        {
            InitializeComponent();
            GameManager.Instance.currentState = GameManager.Instance.fsm.Start();
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            PlayerName.Text = GameManager.Instance.Aries.Name;
            EnemyName.Text = GameManager.Instance.Doomsday.Name;

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
            Debug.WriteLine("Started Combat state...");
            GameManager.Instance.fsm.ChangeState("ATK");
            StateFunctions();
            if (GameManager.Instance.Doomsday.Health != 0)
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            if (GameManager.Instance.Doomsday.Health == 0)
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                EnemyHealth.Value = (int)(((float)GameManager.Instance.Swine.Health / (float)GameManager.Instance.Swine.MaxHealth) * 100f);
            }

            GameManager.Instance.fsm.ChangeState("ENDTURN");
            StateFunctions();
        }


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
            if (GameManager.Instance.currentState == "ATK")
            {
                GameManager.Instance.combat.ToEnter();
            }
            if (GameManager.Instance.currentState == "ENDTURN")
            {
                TextLog.Text += "End of Turn" + "\n";
                TextLog.SelectionStart = TextLog.Text.Length;
                TextLog.ScrollToCaret();
            }
        }

        private void PlayerHealth_Click(object sender, EventArgs e)
        {

        }

        private void EnemyHealth_Click(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading previous save...");

            GameManager.Instance.Aries = DataManager<Player>.Deserialize("AriesPlayer");
            GameManager.Instance.Doomsday = DataManager<Player>.Deserialize("DoomsdayPlayer");
            GameManager.Instance.Swine = DataManager<Player>.Deserialize("SwinePlayer");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            if (GameManager.Instance.Doomsday.Health != 0)
            {
                EnemyName.Text = GameManager.Instance.Doomsday.Name;
                EnemyHealth.Maximum = GameManager.Instance.Doomsday.Health;
                EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            }
            else if (GameManager.Instance.Swine.Health != 0)
            {
                EnemyName.Text = GameManager.Instance.Swine.Name;
                EnemyHealth.Maximum = GameManager.Instance.Swine.Health;
                EnemyHealth.Value = GameManager.Instance.Swine.Health;
            }



            Debug.WriteLine("Previous Save Loaded");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving current progress...");

            DataManager<Player>.Serialize("DoomsdayPlayer", GameManager.Instance.Doomsday);

            DataManager<Player>.Serialize("SwinePlayer", GameManager.Instance.Swine);

            DataManager<Player>.Serialize("AriesPlayer", GameManager.Instance.Aries);
            
            DataManager<string>.Serialize("TextLog", TextLog.Text);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Not Doing anything ATM...");
        }

        private void PlayerName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void EnemyName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Potion_Click(object sender, EventArgs e)
        {

            limit = DataManager<int>.Deserialize("PotionUse");

            if (limit <= 3)
            {
                DataManager<int>.Serialize("PotionUse", limit);
                GameManager.Instance.Aries.Health = GameManager.Instance.Aries.MaxHealth;
                PlayerHealth.Value = GameManager.Instance.Aries.Health;
                limit++;
            }

            else
            {
                Potion.Enabled = false;
            }

        }
    }
}