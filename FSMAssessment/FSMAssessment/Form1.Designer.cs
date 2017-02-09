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
            this.SuspendLayout();
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Location = new System.Drawing.Point(12, 113);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(100, 12);
            this.PlayerHealth.TabIndex = 0;
            this.PlayerHealth.Value = 100;
            // 
            // EnemyHealth
            // 
            this.EnemyHealth.Location = new System.Drawing.Point(249, 113);
            this.EnemyHealth.Name = "EnemyHealth";
            this.EnemyHealth.Size = new System.Drawing.Size(100, 12);
            this.EnemyHealth.TabIndex = 1;
            this.EnemyHealth.Value = 100;
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(12, 13);
            this.TextLog.Name = "TextLog";
            this.TextLog.ReadOnly = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 200);
            this.Controls.Add(this.AtkButton);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.EnemyHealth);
            this.Controls.Add(this.PlayerHealth);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar PlayerHealth;
        private System.Windows.Forms.ProgressBar EnemyHealth;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.Button AtkButton;
    }
}

