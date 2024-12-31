namespace SpaceWar
{
    partial class SpaceWar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceWar));
            this.spaceShipPlayer = new System.Windows.Forms.PictureBox();
            this.bullet = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rock1 = new System.Windows.Forms.PictureBox();
            this.rock2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spaceShipPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rock1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rock2)).BeginInit();
            this.SuspendLayout();
            // 
            // spaceShipPlayer
            // 
            this.spaceShipPlayer.BackColor = System.Drawing.Color.Transparent;
            this.spaceShipPlayer.Image = ((System.Drawing.Image)(resources.GetObject("spaceShipPlayer.Image")));
            this.spaceShipPlayer.Location = new System.Drawing.Point(-1, 200);
            this.spaceShipPlayer.Name = "spaceShipPlayer";
            this.spaceShipPlayer.Size = new System.Drawing.Size(130, 125);
            this.spaceShipPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spaceShipPlayer.TabIndex = 0;
            this.spaceShipPlayer.TabStop = false;
            // 
            // bullet
            // 
            this.bullet.BackColor = System.Drawing.Color.Transparent;
            this.bullet.Image = ((System.Drawing.Image)(resources.GetObject("bullet.Image")));
            this.bullet.Location = new System.Drawing.Point(112, 247);
            this.bullet.Name = "bullet";
            this.bullet.Size = new System.Drawing.Size(62, 33);
            this.bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bullet.TabIndex = 1;
            this.bullet.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rock1
            // 
            this.rock1.BackColor = System.Drawing.Color.Transparent;
            this.rock1.Image = ((System.Drawing.Image)(resources.GetObject("rock1.Image")));
            this.rock1.Location = new System.Drawing.Point(449, 30);
            this.rock1.Name = "rock1";
            this.rock1.Size = new System.Drawing.Size(230, 83);
            this.rock1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rock1.TabIndex = 2;
            this.rock1.TabStop = false;
            // 
            // rock2
            // 
            this.rock2.BackColor = System.Drawing.Color.Transparent;
            this.rock2.Image = ((System.Drawing.Image)(resources.GetObject("rock2.Image")));
            this.rock2.Location = new System.Drawing.Point(288, 395);
            this.rock2.Name = "rock2";
            this.rock2.Size = new System.Drawing.Size(106, 107);
            this.rock2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rock2.TabIndex = 3;
            this.rock2.TabStop = false;
            // 
            // SpaceWar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.spaceShipPlayer);
            this.Controls.Add(this.rock2);
            this.Controls.Add(this.rock1);
            this.Controls.Add(this.bullet);
            this.Name = "SpaceWar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceWar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceWar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spaceShipPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rock1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rock2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spaceShipPlayer;
        private System.Windows.Forms.PictureBox bullet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox rock1;
        private System.Windows.Forms.PictureBox rock2;
    }
}

