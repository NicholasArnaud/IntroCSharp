namespace FSMAssessment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlayerHealth = new System.Windows.Forms.ProgressBar();
            this.EnemyHealth = new System.Windows.Forms.ProgressBar();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.AtkButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Player = new System.Windows.Forms.ToolTip(this.components);
            this.Enemy = new System.Windows.Forms.ToolTip(this.components);
            this.ResetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Location = new System.Drawing.Point(12, 113);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(100, 12);
            this.PlayerHealth.TabIndex = 0;
            this.Player.SetToolTip(this.PlayerHealth, "Player\'s Health");
            this.PlayerHealth.Value = 100;
            this.PlayerHealth.Click += new System.EventHandler(this.PlayerHealth_Click);
            // 
            // EnemyHealth
            // 
            this.EnemyHealth.Location = new System.Drawing.Point(249, 113);
            this.EnemyHealth.Name = "EnemyHealth";
            this.EnemyHealth.Size = new System.Drawing.Size(100, 12);
            this.EnemyHealth.TabIndex = 1;
            this.Enemy.SetToolTip(this.EnemyHealth, "Enemy\'s Health");
            this.EnemyHealth.Value = 100;
            this.EnemyHealth.Click += new System.EventHandler(this.EnemyHealth_Click);
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(12, 13);
            this.TextLog.Name = "TextLog";
            this.TextLog.ReadOnly = true;
            this.TextLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextLog.Size = new System.Drawing.Size(337, 43);
            this.TextLog.TabIndex = 2;
            this.TextLog.Text = "";
            this.TextLog.TextChanged += new System.EventHandler(this.TextLog_TextChanged);
            // 
            // AtkButton
            // 
            this.AtkButton.Location = new System.Drawing.Point(139, 113);
            this.AtkButton.Name = "AtkButton";
            this.AtkButton.Size = new System.Drawing.Size(75, 23);
            this.AtkButton.TabIndex = 3;
            this.AtkButton.Text = "Attack";
            this.AtkButton.UseVisualStyleBackColor = true;
            this.AtkButton.Click += new System.EventHandler(this.AtkButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 165);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(274, 165);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(139, 165);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 200);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.AtkButton);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.EnemyHealth);
            this.Controls.Add(this.PlayerHealth);
            this.Name = "Form1";
            this.Text = "KillSim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PlayerHealth;
        private System.Windows.Forms.ProgressBar EnemyHealth;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.Button AtkButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ToolTip Player;
        private System.Windows.Forms.ToolTip Enemy;
        private System.Windows.Forms.Button ResetButton;
    }
}

