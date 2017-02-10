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

        public Form1()
        {
            InitializeComponent();
            GameManager.Instance.current = GameManager.Instance.fsm.Start();
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            
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
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            GameManager.Instance.fsm.ChangeState("ENDTURN");
            StateFunctions();
        }


        private void StateFunctions()
        {
            if(GameManager.Instance.current == "INIT")
            {
                GameManager.Instance.turnManager.ToStartUp();
            }
            if(GameManager.Instance.current=="IDLE")
            {
                GameManager.Instance.turnManager.Idle();
            }
            if (GameManager.Instance.current == "ATK")
            {
                GameManager.Instance.combat.ToEnter();
            }
            if (GameManager.Instance.current == "ENDTURN")
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
            GameManager.Instance.Aries = DataManager<Player>.Deserialize("FriendlyPLayers");
            GameManager.Instance.Doomsday = DataManager<Player>.Deserialize("EnemyPLayers");
            TextLog.Text = DataManager<string>.Deserialize("TextLog");
            PlayerHealth.Value = GameManager.Instance.Aries.Health;
            EnemyHealth.Value = GameManager.Instance.Doomsday.Health;
            Debug.WriteLine("Previous Save Loaded");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Saving current progress...");
            DataManager<Player>.Serialize("FriendlyPlayers", GameManager.Instance.Aries);
            DataManager<Player>.Serialize("EnemyPlayers", GameManager.Instance.Doomsday);
            DataManager<string>.Serialize("TextLog", TextLog.Text);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Not Doing anything ATM...");
        }
    }
}