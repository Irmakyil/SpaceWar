namespace spacewar.PresentationLayer
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.scoreLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.healthLbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // scoreLbl
            // 
            this.scoreLbl.AutoSize = true;
            this.scoreLbl.BackColor = System.Drawing.Color.PapayaWhip;
            this.scoreLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.scoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.scoreLbl.Location = new System.Drawing.Point(0, 0);
            this.scoreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLbl.Name = "scoreLbl";
            this.scoreLbl.Size = new System.Drawing.Size(91, 25);
            this.scoreLbl.TabIndex = 1;
            this.scoreLbl.Text = "Score : 0";
            this.scoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.healthLbl);
            this.panel1.Controls.Add(this.scoreLbl);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 65);
            this.panel1.TabIndex = 2;
            // 
            // healthLbl
            // 
            this.healthLbl.AutoSize = true;
            this.healthLbl.BackColor = System.Drawing.Color.PapayaWhip;
            this.healthLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.healthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.healthLbl.Location = new System.Drawing.Point(0, 40);
            this.healthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.healthLbl.Name = "healthLbl";
            this.healthLbl.Size = new System.Drawing.Size(95, 25);
            this.healthLbl.TabIndex = 3;
            this.healthLbl.Text = "Health : 0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1019, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Enabled = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceWar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scoreLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label healthLbl;
    }
}

