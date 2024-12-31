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

namespace spacewar.PresentationLayer
{
    public partial class GameForm : Form
    {
        private Game game;
        private Timer gameTimer;
        private Bitmap playerImage;
        private Bitmap enemyImage;
        private Bitmap bulletImage;
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
            playerImage = new Bitmap("C:\\Users\\Ataberk\\source\\repos\\spacewar\\spacewar.PresentationLayer\\Resources\\Corvette.png");
            enemyImage = new Bitmap("C:\\Users\\Ataberk\\source\\repos\\spacewar\\spacewar.PresentationLayer\\Resources\\CorvetteB.png");
            bulletImage = new Bitmap("C:\\Users\\Ataberk\\source\\repos\\spacewar\\spacewar.PresentationLayer\\Resources\\star_red02.png");
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
                return; // Stop updating game state when game is over
            }

            scoreLbl.Text = "Score : " + game.Score.ToString();
            healthLbl.Text = "Health : " + game.Player.Health.ToString();
            game.UpdateGame();

            if (game.IsGameOver)
            {
                EndGame();
            }

            Invalidate(); // Trigger repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!isGameOver)
            {
                // Render game objects
                RenderPlayer(e.Graphics);
                RenderEnemies(e.Graphics);
                RenderBullets(e.Graphics);
            }
            else
            {
                // Render game over screen
                RenderGameOverScreen(e.Graphics);
            }
        }

        private void RenderGameOverScreen(Graphics g)
        {
            // Create a semi-transparent overlay
            using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                g.FillRectangle(overlayBrush, this.ClientRectangle);
            }

            // Prepare font and colors
            using (Font gameOverFont = new Font("Arial", 48, FontStyle.Bold))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                // Draw "GAME OVER" text
                string gameOverText = "GAME OVER";
                SizeF textSize = g.MeasureString(gameOverText, gameOverFont);
                PointF textPosition = new PointF(
                    (this.ClientSize.Width - textSize.Width) / 2,
                    (this.ClientSize.Height - textSize.Height) / 2 - 50
                );
                g.DrawString(gameOverText, gameOverFont, textBrush, textPosition);

                // Draw score
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

                // Draw restart instructions
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
            // Draw player spaceship
            g.DrawImage(playerImage, game.Player.PositionX, game.Player.PositionY, 30, 20);
        }

        private void RenderEnemies(Graphics g)
        {
            // Draw enemies
            foreach (var enemy in game.Enemies)
            {
                g.DrawImage(enemyImage, enemy.SpawnX, enemy.SpawnY, 30, 20);
            }
        }

        private void RenderBullets(Graphics g)
        {
            // Draw player bullets
            foreach (var bullet in game.Player.Bullets)
            {
                g.DrawImage(bulletImage, bullet.PositionX, bullet.PositionY, 5, 5);
            }

            // Draw enemy bullets
            foreach (var enemy in game.Enemies)
            {
                foreach (var bullet in enemy.Bullets)
                {
                    g.DrawImage(bulletImage, bullet.PositionX, bullet.PositionY, 5, 5);
                }
            }
        }

        // Add key event handlers for player movement, shooting, and game over interactions
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (isGameOver)
            {
                // Handle game over state key presses
                switch (e.KeyCode)
                {
                    case Keys.R:
                        RestartGame();
                        break;
                    case Keys.Escape:
                        this.Close();
                        break;
                        return;
                }
            }

            // Normal game controls
            switch (e.KeyCode)
            {
                case Keys.Up:
                    game.Player.Move(-1);
                    break;
                case Keys.Down:
                    game.Player.Move(1);
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
            Invalidate(); // Trigger repaint to show game over screen
        }

        private void RestartGame()
        {
            // Reset game state
            game = new Game();
            isGameOver = false;
            gameTimer.Start();
            Invalidate();
        }

        // Implement Dispose method to clean up resources
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