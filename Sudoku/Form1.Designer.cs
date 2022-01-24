using System.Drawing;

namespace Sudoku
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
            this.BackColor = Color.Black;
            this.panel1 = new System.Windows.Forms.Panel();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            //this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(658, 73);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(228, 55);
            this.button17.TabIndex = 1;
            this.button17.Text = "Check";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.BackColor = Color.LightSteelBlue;
            this.button17.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(658, 150);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(228, 57);
            this.button18.TabIndex = 2;
            this.button18.Text = "Clear All";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.BackColor = Color.LightSteelBlue;
            this.button18.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(658, 230);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(228, 57);
            this.button19.TabIndex = 3;
            this.button19.Text = "Show solution";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.BackColor = Color.LightSteelBlue;
            this.button19.Click += new System.EventHandler(this.ShowSolution_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(658, 428);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(98, 24);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Begginer";
            this.radioButton1.ForeColor = Color.LightSteelBlue;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(781, 428);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(105, 24);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Advanced";
            this.radioButton2.ForeColor = Color.LightSteelBlue;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 471);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 55);
            this.button1.TabIndex = 8;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.BackColor = Color.RosyBrown;
            this.button1.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 667);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
    }

}

