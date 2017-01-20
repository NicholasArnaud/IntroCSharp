namespace Serialization_Practice
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
            this.label1 = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.TextBox();
            this.StudentAge = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StudentID = new System.Windows.Forms.TextBox();
            this.SaveData1 = new System.Windows.Forms.Button();
            this.LoadLast1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentAge)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // StudentName
            // 
            this.StudentName.Location = new System.Drawing.Point(12, 25);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(100, 20);
            this.StudentName.TabIndex = 1;
            // 
            // StudentAge
            // 
            this.StudentAge.Location = new System.Drawing.Point(12, 64);
            this.StudentAge.Name = "StudentAge";
            this.StudentAge.Size = new System.Drawing.Size(58, 20);
            this.StudentAge.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID Number";
            // 
            // StudentID
            // 
            this.StudentID.Location = new System.Drawing.Point(12, 103);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(100, 20);
            this.StudentID.TabIndex = 5;
            // 
            // SaveData1
            // 
            this.SaveData1.Location = new System.Drawing.Point(12, 129);
            this.SaveData1.Name = "SaveData1";
            this.SaveData1.Size = new System.Drawing.Size(75, 23);
            this.SaveData1.TabIndex = 6;
            this.SaveData1.Text = "Save File 1";
            this.SaveData1.UseVisualStyleBackColor = true;
            this.SaveData1.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // LoadLast1
            // 
            this.LoadLast1.Location = new System.Drawing.Point(93, 129);
            this.LoadLast1.Name = "LoadLast1";
            this.LoadLast1.Size = new System.Drawing.Size(75, 23);
            this.LoadLast1.TabIndex = 7;
            this.LoadLast1.Text = "Load File 1";
            this.LoadLast1.UseVisualStyleBackColor = true;
            this.LoadLast1.Click += new System.EventHandler(this.LoadLast_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 159);
            this.Controls.Add(this.LoadLast1);
            this.Controls.Add(this.SaveData1);
            this.Controls.Add(this.StudentID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StudentAge);
            this.Controls.Add(this.StudentName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StudentName;
        private System.Windows.Forms.NumericUpDown StudentAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StudentID;
        private System.Windows.Forms.Button SaveData1;
        private System.Windows.Forms.Button LoadLast1;
    }
}