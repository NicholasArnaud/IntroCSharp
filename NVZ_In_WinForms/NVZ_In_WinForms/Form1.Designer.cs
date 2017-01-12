namespace NVZ_In_WinForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GuySelect = new System.Windows.Forms.Button();
            this.LegSelect = new System.Windows.Forms.Button();
            this.KillaSelect = new System.Windows.Forms.Button();
            this.RektSelect = new System.Windows.Forms.Button();
            this.KillaHealth = new System.Windows.Forms.ProgressBar();
            this.RektHealth = new System.Windows.Forms.ProgressBar();
            this.LegendHealth = new System.Windows.Forms.ProgressBar();
            this.GuyHealth = new System.Windows.Forms.ProgressBar();
            this.ATKGuy = new System.Windows.Forms.Button();
            this.ATKLeg = new System.Windows.Forms.Button();
            this.ATKKilla = new System.Windows.Forms.Button();
            this.ATKRekt = new System.Windows.Forms.Button();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GuySelect
            // 
            this.GuySelect.Location = new System.Drawing.Point(51, 591);
            this.GuySelect.Name = "GuySelect";
            this.GuySelect.Size = new System.Drawing.Size(142, 30);
            this.GuySelect.TabIndex = 0;
            this.GuySelect.Text = "TheGuy";
            this.GuySelect.UseVisualStyleBackColor = true;
            this.GuySelect.Click += new System.EventHandler(this.GuySelect_Click);
            // 
            // LegSelect
            // 
            this.LegSelect.Location = new System.Drawing.Point(253, 591);
            this.LegSelect.Name = "LegSelect";
            this.LegSelect.Size = new System.Drawing.Size(145, 30);
            this.LegSelect.TabIndex = 1;
            this.LegSelect.Text = "TheLegend27";
            this.LegSelect.UseVisualStyleBackColor = true;
            this.LegSelect.Click += new System.EventHandler(this.LegSelect_Click);
            // 
            // KillaSelect
            // 
            this.KillaSelect.Location = new System.Drawing.Point(866, 591);
            this.KillaSelect.Name = "KillaSelect";
            this.KillaSelect.Size = new System.Drawing.Size(134, 30);
            this.KillaSelect.TabIndex = 2;
            this.KillaSelect.Text = "NoobKilla";
            this.KillaSelect.UseVisualStyleBackColor = true;
            this.KillaSelect.Click += new System.EventHandler(this.KillaSelect_Click);
            // 
            // RektSelect
            // 
            this.RektSelect.Location = new System.Drawing.Point(1109, 591);
            this.RektSelect.Name = "RektSelect";
            this.RektSelect.Size = new System.Drawing.Size(135, 30);
            this.RektSelect.TabIndex = 3;
            this.RektSelect.Text = "GetRekt";
            this.RektSelect.UseVisualStyleBackColor = true;
            this.RektSelect.Click += new System.EventHandler(this.RektSelect_Click);
            // 
            // KillaHealth
            // 
            this.KillaHealth.Location = new System.Drawing.Point(884, 553);
            this.KillaHealth.Name = "KillaHealth";
            this.KillaHealth.Size = new System.Drawing.Size(100, 23);
            this.KillaHealth.TabIndex = 4;
            this.KillaHealth.Click += new System.EventHandler(this.KillaHealth_Click);
            // 
            // RektHealth
            // 
            this.RektHealth.Location = new System.Drawing.Point(1129, 553);
            this.RektHealth.Name = "RektHealth";
            this.RektHealth.Size = new System.Drawing.Size(100, 23);
            this.RektHealth.TabIndex = 5;
            this.RektHealth.Click += new System.EventHandler(this.RektHealth_Click);
            // 
            // LegendHealth
            // 
            this.LegendHealth.Location = new System.Drawing.Point(275, 553);
            this.LegendHealth.Name = "LegendHealth";
            this.LegendHealth.Size = new System.Drawing.Size(100, 23);
            this.LegendHealth.TabIndex = 6;
            this.LegendHealth.Click += new System.EventHandler(this.LegendHealth_Click);
            // 
            // GuyHealth
            // 
            this.GuyHealth.Location = new System.Drawing.Point(70, 553);
            this.GuyHealth.Name = "GuyHealth";
            this.GuyHealth.Size = new System.Drawing.Size(100, 23);
            this.GuyHealth.TabIndex = 7;
            this.GuyHealth.Click += new System.EventHandler(this.GuyHealth_Click);
            // 
            // ATKGuy
            // 
            this.ATKGuy.Location = new System.Drawing.Point(70, 450);
            this.ATKGuy.Name = "ATKGuy";
            this.ATKGuy.Size = new System.Drawing.Size(100, 52);
            this.ATKGuy.TabIndex = 8;
            this.ATKGuy.Text = "ATTACK";
            this.ATKGuy.UseVisualStyleBackColor = true;
            this.ATKGuy.Visible = false;
            this.ATKGuy.Click += new System.EventHandler(this.ATKGuy_Click);
            // 
            // ATKLeg
            // 
            this.ATKLeg.Location = new System.Drawing.Point(275, 450);
            this.ATKLeg.Name = "ATKLeg";
            this.ATKLeg.Size = new System.Drawing.Size(100, 52);
            this.ATKLeg.TabIndex = 9;
            this.ATKLeg.Text = "ATTACK";
            this.ATKLeg.UseVisualStyleBackColor = true;
            this.ATKLeg.Visible = false;
            this.ATKLeg.Click += new System.EventHandler(this.ATKLeg_Click);
            // 
            // ATKKilla
            // 
            this.ATKKilla.Location = new System.Drawing.Point(884, 450);
            this.ATKKilla.Name = "ATKKilla";
            this.ATKKilla.Size = new System.Drawing.Size(100, 52);
            this.ATKKilla.TabIndex = 10;
            this.ATKKilla.Text = "ATTACK";
            this.ATKKilla.UseVisualStyleBackColor = true;
            this.ATKKilla.Visible = false;
            this.ATKKilla.Click += new System.EventHandler(this.ATKKilla_Click);
            // 
            // ATKRekt
            // 
            this.ATKRekt.Location = new System.Drawing.Point(1129, 450);
            this.ATKRekt.Name = "ATKRekt";
            this.ATKRekt.Size = new System.Drawing.Size(100, 52);
            this.ATKRekt.TabIndex = 11;
            this.ATKRekt.Text = "ATTACK";
            this.ATKRekt.UseVisualStyleBackColor = true;
            this.ATKRekt.Visible = false;
            this.ATKRekt.Click += new System.EventHandler(this.ATKRekt_Click);
            // 
            // LogBox
            // 
            this.LogBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.LogBox.Enabled = false;
            this.LogBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.LogBox.Location = new System.Drawing.Point(436, 287);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(358, 20);
            this.LogBox.TabIndex = 12;
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1287, 657);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.ATKRekt);
            this.Controls.Add(this.ATKKilla);
            this.Controls.Add(this.ATKLeg);
            this.Controls.Add(this.ATKGuy);
            this.Controls.Add(this.GuyHealth);
            this.Controls.Add(this.LegendHealth);
            this.Controls.Add(this.RektHealth);
            this.Controls.Add(this.KillaHealth);
            this.Controls.Add(this.RektSelect);
            this.Controls.Add(this.KillaSelect);
            this.Controls.Add(this.LegSelect);
            this.Controls.Add(this.GuySelect);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.Text = "NinjaVsZombie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GuySelect;
        private System.Windows.Forms.Button LegSelect;
        private System.Windows.Forms.Button KillaSelect;
        private System.Windows.Forms.Button RektSelect;
        private System.Windows.Forms.ProgressBar KillaHealth;
        private System.Windows.Forms.ProgressBar RektHealth;
        private System.Windows.Forms.ProgressBar LegendHealth;
        private System.Windows.Forms.ProgressBar GuyHealth;
        private System.Windows.Forms.Button ATKGuy;
        private System.Windows.Forms.Button ATKLeg;
        private System.Windows.Forms.Button ATKKilla;
        private System.Windows.Forms.Button ATKRekt;
        private System.Windows.Forms.TextBox LogBox;
    }
}

