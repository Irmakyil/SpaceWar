using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceWar
{
    public partial class SpaceWar : Form
    {

        private Random rnd = new Random(); // Class-level Random instance
        private int score = 0;
        public SpaceWar()
        {
            InitializeComponent();
        }

        void Bullet()
        {
            bullet.Left += 10;
            if (bullet.Left > this.ClientSize.Width)
            {
                ResetBullet();
            }

        }
        private void ResetBullet()
        {
            bullet.Left = spaceShipPlayer.Left;
            bullet.Top = spaceShipPlayer.Top + 35;
        }

        void Rocks()
        {
            MoveRock(rock1);
            MoveRock(rock2);
        }
        private void MoveRock(PictureBox rock)
        {
            rock.Left -= 2;
            if (rock.Left < 0)
            {
                rock.Location = new Point(this.ClientSize.Width, rnd.Next(0, this.ClientSize.Height - rock.Height));
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           ResetGame();
        }

        private void ResetGame()
        {
            bullet.Left = spaceShipPlayer.Left;
            bullet.Top = spaceShipPlayer.Top + 35;
            rock1.Location = new Point(800, rnd.Next(0, 400));
            rock2.Location = new Point(800, rnd.Next(0, 500));
            score = 0;
        }


        private void SpaceWar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (spaceShipPlayer.Top > 20)
                {
                    spaceShipPlayer.Top -= 5;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (spaceShipPlayer.Top < 350)
                {
                    spaceShipPlayer.Top += 5;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bullet();
            Rocks();
        }
    }
}
