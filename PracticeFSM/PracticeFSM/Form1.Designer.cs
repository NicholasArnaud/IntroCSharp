namespace PracticeFSM
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
            this.Attack = new System.Windows.Forms.Button();
            this.Defend = new System.Windows.Forms.Button();
            this.End = new System.Windows.Forms.Button();
            this.CloudSelect = new System.Windows.Forms.Button();
            this.TifaSelect = new System.Windows.Forms.Button();
            this.BarettSelect = new System.Windows.Forms.Button();
            this.AerisSelect = new System.Windows.Forms.Button();
            this.VincentSelect = new System.Windows.Forms.Button();
            this.CaitSithSelect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Attack
            // 
            this.Attack.Location = new System.Drawing.Point(82, 226);
            this.Attack.Name = "Attack";
            this.Attack.Size = new System.Drawing.Size(75, 23);
            this.Attack.TabIndex = 0;
            this.Attack.Text = "ATK";
            this.Attack.UseVisualStyleBackColor = true;
            this.Attack.Click += new System.EventHandler(this.Attack_Click);
            // 
            // Defend
            // 
            this.Defend.Location = new System.Drawing.Point(205, 226);
            this.Defend.Name = "Defend";
            this.Defend.Size = new System.Drawing.Size(75, 23);
            this.Defend.TabIndex = 1;
            this.Defend.Text = "Defend";
            this.Defend.UseVisualStyleBackColor = true;
            this.Defend.Click += new System.EventHandler(this.Defend_Click);
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(322, 226);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(75, 23);
            this.End.TabIndex = 2;
            this.End.Text = "END";
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // CloudSelect
            // 
            this.CloudSelect.Location = new System.Drawing.Point(62, 23);
            this.CloudSelect.Name = "CloudSelect";
            this.CloudSelect.Size = new System.Drawing.Size(75, 23);
            this.CloudSelect.TabIndex = 3;
            this.CloudSelect.Text = "Cloud";
            this.CloudSelect.UseVisualStyleBackColor = true;
            this.CloudSelect.Click += new System.EventHandler(this.CloudSelect_Click);
            // 
            // TifaSelect
            // 
            this.TifaSelect.Location = new System.Drawing.Point(62, 71);
            this.TifaSelect.Name = "TifaSelect";
            this.TifaSelect.Size = new System.Drawing.Size(75, 23);
            this.TifaSelect.TabIndex = 4;
            this.TifaSelect.Text = "Tifa";
            this.TifaSelect.UseVisualStyleBackColor = true;
            this.TifaSelect.Click += new System.EventHandler(this.TifaSelect_Click);
            // 
            // BarettSelect
            // 
            this.BarettSelect.Location = new System.Drawing.Point(62, 122);
            this.BarettSelect.Name = "BarettSelect";
            this.BarettSelect.Size = new System.Drawing.Size(75, 23);
            this.BarettSelect.TabIndex = 5;
            this.BarettSelect.Text = "Barett";
            this.BarettSelect.UseVisualStyleBackColor = true;
            this.BarettSelect.Click += new System.EventHandler(this.BarettSelect_Click);
            // 
            // AerisSelect
            // 
            this.AerisSelect.Location = new System.Drawing.Point(335, 23);
            this.AerisSelect.Name = "AerisSelect";
            this.AerisSelect.Size = new System.Drawing.Size(75, 23);
            this.AerisSelect.TabIndex = 6;
            this.AerisSelect.Text = "Aeris";
            this.AerisSelect.UseVisualStyleBackColor = true;
            this.AerisSelect.Click += new System.EventHandler(this.AerisSelect_Click);
            // 
            // VincentSelect
            // 
            this.VincentSelect.Location = new System.Drawing.Point(335, 71);
            this.VincentSelect.Name = "VincentSelect";
            this.VincentSelect.Size = new System.Drawing.Size(75, 23);
            this.VincentSelect.TabIndex = 7;
            this.VincentSelect.Text = "Vincent";
            this.VincentSelect.UseVisualStyleBackColor = true;
            this.VincentSelect.Click += new System.EventHandler(this.VincentSelect_Click);
            // 
            // CaitSithSelect
            // 
            this.CaitSithSelect.Location = new System.Drawing.Point(335, 122);
            this.CaitSithSelect.Name = "CaitSithSelect";
            this.CaitSithSelect.Size = new System.Drawing.Size(75, 23);
            this.CaitSithSelect.TabIndex = 8;
            this.CaitSithSelect.Text = "CaitSith";
            this.CaitSithSelect.UseVisualStyleBackColor = true;
            this.CaitSithSelect.Click += new System.EventHandler(this.CaitSithSelect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 309);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CaitSithSelect);
            this.Controls.Add(this.VincentSelect);
            this.Controls.Add(this.AerisSelect);
            this.Controls.Add(this.BarettSelect);
            this.Controls.Add(this.TifaSelect);
            this.Controls.Add(this.CloudSelect);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Defend);
            this.Controls.Add(this.Attack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Attack;
        private System.Windows.Forms.Button Defend;
        private System.Windows.Forms.Button End;
        private System.Windows.Forms.Button CloudSelect;
        private System.Windows.Forms.Button TifaSelect;
        private System.Windows.Forms.Button BarettSelect;
        private System.Windows.Forms.Button AerisSelect;
        private System.Windows.Forms.Button VincentSelect;
        private System.Windows.Forms.Button CaitSithSelect;
        private System.Windows.Forms.TextBox textBox1;
    }
}

