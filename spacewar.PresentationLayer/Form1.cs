    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using spacewar.BusinessLogicLayer;
    using spacewar.BusinessLogicLayer.Enemies;

    namespace spacewar.PresentationLayer
    {
        public partial class GameForm : Form
        {
            private Game game;
            private Timer gameTimer;
            private Bitmap playerImage;
            private Bitmap enemyImage;
            private Bitmap enemy2Image;
            private Bitmap enemy3Image;
            private Bitmap enemy4Image;
            private Bitmap bulletImage;
            private Bitmap bulletEnemyImage;
            private Bitmap rockImage;
            private Bitmap powerUpHealth;
            private Bitmap powerUpSpeed;
            private Bitmap powerUpDamage;
            private bool isGameOver = false;

            public GameForm()
            {
                game = new Game();
                InitializeGameForm();
                InitializeGameTimer();
                InitializeComponent();
                LoadAssets();
            }

            private void LoadAssets()
            {
                playerImage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\Player.png");
                enemyImage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\BasicEnemy.png");
                enemy2Image = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\FastEnemy.png");
                enemy3Image = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\StrongEnemy.png");
                enemy4Image = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\BossEnemy.png");
                bulletImage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\bullet.png");
                bulletEnemyImage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\star_blue02.png");
                rockImage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\rock2.png");
                powerUpHealth = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\health.png");
                powerUpSpeed = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\speed.png");
                powerUpDamage = new Bitmap("C:\\Users\\IRMAK\\Desktop\\spacewar\\spacewar.PresentationLayer\\Resources\\damage.png");
            }

            private void InitializeGameForm()
            {
                this.Size = new Size(800, 600);
                this.Text = "SpaceWar Game";
                this.DoubleBuffered = true;
            }

            private void InitializeGameTimer()
            {
                gameTimer = new Timer();
                gameTimer.Interval = 16; // 60 FPS
                gameTimer.Tick += UpdateGame;
                gameTimer.Start();
            }

            private void UpdateGame(object sender, EventArgs e)
            {
                if (isGameOver)
                {
                    return; 
                }

                scoreLbl.Text = "Score : " + game.Score.ToString();
                healthLbl.Text = "Health : " + game.Player.Health.ToString();
                game.UpdateGame();

                if (game.IsGameOver)
                {
                    EndGame();
                }

                Invalidate(); 
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                if (!isGameOver)
                {
                
                    RenderPlayer(e.Graphics);
                    RenderEnemy1(e.Graphics);
                    RenderEnemy2(e.Graphics);
                    RenderEnemy3(e.Graphics);
                    RenderEnemy4(e.Graphics);
                    RenderBullets(e.Graphics);
                    RenderRocks(e.Graphics);
                    RenderHealth(e.Graphics);
                    RenderSpeed(e.Graphics);
                    RenderDamage(e.Graphics);
                
                }
                else
                {
                    RenderGameOverScreen(e.Graphics);
                }
            }

            private void RenderGameOverScreen(Graphics g)
            {
            
                using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    g.FillRectangle(overlayBrush, this.ClientRectangle);
                }

                using (Font gameOverFont = new Font("Arial", 48, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                
                    string gameOverText = "GAME OVER";
                    SizeF textSize = g.MeasureString(gameOverText, gameOverFont);
                    PointF textPosition = new PointF(
                        (this.ClientSize.Width - textSize.Width) / 2,
                        (this.ClientSize.Height - textSize.Height) / 2 - 50
                    );
                    g.DrawString(gameOverText, gameOverFont, textBrush, textPosition);

                    using (Font scoreFont = new Font("Arial", 24))
                    {
                        string scoreText = $"Score: {game.Score}";
                        SizeF scoreTextSize = g.MeasureString(scoreText, scoreFont);
                        PointF scorePosition = new PointF(
                            (this.ClientSize.Width - scoreTextSize.Width) / 2,
                            textPosition.Y + textSize.Height + 20
                        );
                        g.DrawString(scoreText, scoreFont, textBrush, scorePosition);
                    }

                    using (Font instructionFont = new Font("Arial", 16))
                    {
                        string instructionText = "Press 'R' to Restart or 'Esc' to Quit";
                        SizeF instructionTextSize = g.MeasureString(instructionText, instructionFont);
                        PointF instructionPosition = new PointF(
                            (this.ClientSize.Width - instructionTextSize.Width) / 2,
                            this.ClientSize.Height - 100
                        );
                        g.DrawString(instructionText, instructionFont, textBrush, instructionPosition);
                    }
                }
            }

            private void RenderPlayer(Graphics g)
            {
            
                g.DrawImage(playerImage, game.Player.PositionX, game.Player.PositionY, 30, 20);
            }

            private void RenderEnemy1(Graphics g)
            {
                foreach (var enemy in game.Enemy1)
                {
                    g.DrawImage(enemyImage, enemy.SpawnX, enemy.SpawnY, 30, 20);
                }
            }

            private void RenderEnemy2(Graphics g)
            {
                foreach(var enemy in game.Enemy2)
                {
                    g.DrawImage(enemy2Image, enemy.SpawnX, enemy.SpawnY, 30, 20);
                }
            }
            private void RenderEnemy3(Graphics g)
            {
                foreach (var enemy in game.Enemy3)
                {
                    g.DrawImage(enemy3Image, enemy.SpawnX, enemy.SpawnY, 30, 20);
                }
            }
            private void RenderEnemy4(Graphics g)
            {
                foreach (var enemy in game.Enemy4)
                {
                    g.DrawImage(enemy4Image, enemy.SpawnX, enemy.SpawnY, 30, 20);
                }
            }
            private void RenderBullets(Graphics g)
            {
                foreach (var bullet in game.Player.Bullets)
                {
                    g.DrawImage(bulletImage, bullet.PositionX, bullet.PositionY, 5, 5);
                }

                foreach (var enemy in game.Enemy1)
                {
                    foreach (var bullet in enemy.Bullets)
                    {
                        g.DrawImage(bulletEnemyImage, bullet.PositionX, bullet.PositionY, 5, 5);
                    }
                }
                foreach (var enemy in game.Enemy2)
                {
                    foreach (var bullet in enemy.Bullets)
                    {
                        g.DrawImage(bulletEnemyImage, bullet.PositionX, bullet.PositionY, 5, 5);
                    }
                }
                foreach (var enemy in game.Enemy3)
                {
                    foreach (var bullet in enemy.Bullets)
                    {
                        g.DrawImage(bulletEnemyImage, bullet.PositionX, bullet.PositionY, 5, 5);
                    }
                }
                foreach (var enemy in game.Enemy4)
                {
                    foreach (var bullet in enemy.Bullets)
                    {
                        g.DrawImage(bulletEnemyImage, bullet.PositionX, bullet.PositionY, 5, 5);
                    }
                }

            }
        private void RenderRocks(Graphics g)
        {
            foreach (var rocks in game.rocks)
            {
                g.DrawImage(rockImage, rocks.X, rocks.Y, 40, 40);
            }
        }

        private void RenderHealth(Graphics g)
            {
                foreach (var drop in game.Health)
                {
                    g.DrawImage(powerUpHealth, drop.X, drop.Y, 40, 50);
                }
            }
            private void RenderSpeed(Graphics g)
            {
                foreach (var drop in game.Speeds)
                {
                    g.DrawImage(powerUpSpeed, drop.X, drop.Y, 40, 50);
                }
            }
            private void RenderDamage(Graphics g)
            {
                foreach (var drop in game.Damages)
                {
                    g.DrawImage(powerUpDamage, drop.X, drop.Y, 40, 50);
                }
            }

            protected override void OnKeyDown(KeyEventArgs e)
            {
                base.OnKeyDown(e);

                if (isGameOver)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.R:
                            RestartGame();
                            break;
                        case Keys.Escape:
                            this.Close();
                            break;
                            //return;
                    }
                }

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        game.Player.Move(0,-1);
                        break;
                    case Keys.Down:
                        game.Player.Move(0,1);
                        break;
                    case Keys.Right:
                        game.Player.Move(1,0);
                        break;
                    case Keys.Left:
                        game.Player.Move(-1,0);
                        break;
                    case Keys.Space:
                        game.Player.Shoot();
                        break;
                }
            }

            private void EndGame()
            {
                gameTimer.Stop();
                isGameOver = true;
                Invalidate(); 
            }

            private void RestartGame()
            {
                game = new Game();
                isGameOver = false;
                gameTimer.Start();
                Invalidate();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    playerImage?.Dispose();
                    enemyImage?.Dispose();
                    bulletImage?.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }