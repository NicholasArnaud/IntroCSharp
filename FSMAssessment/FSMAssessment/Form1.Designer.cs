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
            this.PlayerHealth = new System.Windows.Forms.ProgressBar();
            this.EnemyHealth = new System.Windows.Forms.ProgressBar();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.AtkButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.PlayerName = new System.Windows.Forms.MaskedTextBox();
            this.EnemyName = new System.Windows.Forms.MaskedTextBox();
            this.Potion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Location = new System.Drawing.Point(12, 131);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(100, 12);
            this.PlayerHealth.TabIndex = 0;
            this.PlayerHealth.Value = 100;
            this.PlayerHealth.Click += new System.EventHandler(this.PlayerHealth_Click);
            // 
            // EnemyHealth
            // 
            this.EnemyHealth.Location = new System.Drawing.Point(249, 131);
            this.EnemyHealth.Name = "EnemyHealth";
            this.EnemyHealth.Size = new System.Drawing.Size(100, 12);
            this.EnemyHealth.TabIndex = 1;
            this.EnemyHealth.Value = 100;
            this.EnemyHealth.Click += new System.EventHandler(this.EnemyHealth_Click);
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(12, 13);
            this.TextLog.Name = "TextLog";
            this.TextLog.ReadOnly = true;
            this.TextLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextLog.Size = new System.Drawing.Size(337, 86);
            this.TextLog.TabIndex = 2;
            this.TextLog.Text = "";
            this.TextLog.TextChanged += new System.EventHandler(this.TextLog_TextChanged);
            // 
            // AtkButton
            // 
            this.AtkButton.Location = new System.Drawing.Point(139, 131);
            this.AtkButton.Name = "AtkButton";
            this.AtkButton.Size = new System.Drawing.Size(75, 23);
            this.AtkButton.TabIndex = 3;
            this.AtkButton.Text = "Attack";
            this.AtkButton.UseVisualStyleBackColor = true;
            this.AtkButton.Click += new System.EventHandler(this.AtkButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 178);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(274, 178);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(139, 178);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 6;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // PlayerName
            // 
            this.PlayerName.Location = new System.Drawing.Point(12, 105);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            this.PlayerName.Size = new System.Drawing.Size(100, 20);
            this.PlayerName.TabIndex = 7;
            this.PlayerName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.PlayerName_MaskInputRejected);
            // 
            // EnemyName
            // 
            this.EnemyName.Location = new System.Drawing.Point(249, 105);
            this.EnemyName.Name = "EnemyName";
            this.EnemyName.ReadOnly = true;
            this.EnemyName.Size = new System.Drawing.Size(100, 20);
            this.EnemyName.TabIndex = 8;
            this.EnemyName.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.EnemyName_MaskInputRejected);
            // 
            // Potion
            // 
            this.Potion.Location = new System.Drawing.Point(12, 149);
            this.Potion.Name = "Potion";
            this.Potion.Size = new System.Drawing.Size(75, 23);
            this.Potion.TabIndex = 9;
            this.Potion.Text = "Potion";
            this.Potion.UseVisualStyleBackColor = true;
            this.Potion.Click += new System.EventHandler(this.Potion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 213);
            this.Controls.Add(this.Potion);
            this.Controls.Add(this.EnemyName);
            this.Controls.Add(this.PlayerName);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PlayerHealth;
        private System.Windows.Forms.ProgressBar EnemyHealth;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.Button AtkButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.MaskedTextBox PlayerName;
        private System.Windows.Forms.MaskedTextBox EnemyName;
        private System.Windows.Forms.Button Potion;
    }
}

