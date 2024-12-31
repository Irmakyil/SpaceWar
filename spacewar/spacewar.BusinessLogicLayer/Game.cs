using spacewar.BusinessLogicLayer.Enemies;
using spacewar.BusinessLogicLayer.Utilities;
using spacewar.BusinessLogicLayer;
using System.Collections.Generic;
using System.Timers;
using System;

public class Game
{
    public Spaceship Player { get; private set; }
    public List<Enemy> Enemies { get; private set; }
    public bool IsGameOver { get; private set; }
    public int Score { get; private set; }
    private Timer enemySpawnTimer;

    // Define the window dimensions
    private const int WindowWidth = 800;
    private const int WindowHeight = 600;

    public Game()
    {
        Enemies = new List<Enemy>();
        StartGame();
    }

    public void StartGame()
    {
        Player = new Spaceship(100, 20, 15);

        SpawnEnemies();

        enemySpawnTimer = new Timer(5000);
        enemySpawnTimer.Elapsed += SpawnEnemyOnTimer;
        enemySpawnTimer.AutoReset = true;
        enemySpawnTimer.Start();

        IsGameOver = false;
        Score = 0;
    }

    private void SpawnEnemies()
    {
        Random random = new Random();
        Enemies.Add(new BasicEnemy(random.Next(600, 800), random.Next(500)));
        Enemies.Add(new FastEnemy(random.Next(600, 800), random.Next(500)));
        Enemies.Add(new StrongEnemy(random.Next(600, 800), random.Next(500)));
        Enemies.Add(new BossEnemy(random.Next(600, 800), random.Next(500)));
    }

    private void SpawnEnemyOnTimer(object sender, ElapsedEventArgs e)
    {
        Random random = new Random();
        int enemyType = random.Next(0, 4);

        switch (enemyType)
        {
            case 0:
                Enemies.Add(new BasicEnemy(random.Next(600, 800), random.Next(500)));
                break;
            case 1:
                Enemies.Add(new FastEnemy(random.Next(600, 800), random.Next(500)));
                break;
            case 2:
                Enemies.Add(new StrongEnemy(random.Next(600, 800), random.Next(500)));
                break;
            case 3:
                Enemies.Add(new BossEnemy(random.Next(600, 800), random.Next(500)));
                break;
        }
    }

    public void UpdateGame()
    {
        Player.Update();
        var currentEnemies = new List<Enemy>(Enemies);

        foreach (var enemy in currentEnemies)
        {
            enemy.Move();

            //// Check if enemy is outside the window
            //if (enemy.SpawnX < 0 || enemy.SpawnX > WindowWidth || enemy.SpawnY < 0 || enemy.SpawnY > WindowHeight)
            //{
            //    EndGame(); // Trigger game-over
            //    return;
            //}
        }

        CheckCollisions();

        Enemies.RemoveAll(e => e.Health <= 0);

        if (Player.Health <= 0)
        {
            EndGame();
        }
    }
    private void AdjustEnemyPositionAfterCollision(Enemy enemy)
    {
        // Example: Push the enemy away from the player
        if (enemy.SpawnX < Player.PositionX)
        {
            enemy.SpawnX -= 10; // Move enemy left
        }
        else
        {
            enemy.SpawnX += 10; // Move enemy right
        }

        if (enemy.SpawnY < Player.PositionY)
        {
            enemy.SpawnY -= 10; // Move enemy up
        }
        else
        {
            enemy.SpawnY += 10; // Move enemy down
        }
    }
    private void CheckCollisions()
    {
        CollisionDetector collisionDetector = new CollisionDetector();

        foreach (var bullet in Player.Bullets)
        {
            foreach (var enemy in Enemies)
            {
                if (collisionDetector.CheckBulletCollision(bullet, enemy))
                {
                    bullet.OnHit();
                    enemy.TakeDamage(bullet.Damage);
                    Score += 10;
                }
            }
        }

        foreach (var enemy in Enemies)
        {
            foreach (var bullet in enemy.Bullets)
            {
                if (collisionDetector.CheckBulletCollision(bullet, Player))
                {
                    bullet.OnHit();
                    Player.TakeDamage(bullet.Damage);
                }
            }
        }

        foreach (var enemy in Enemies)
        {
            if (collisionDetector.CheckCollision(Player, enemy))
            {
                Player.TakeDamage(enemy.Damage);
                AdjustEnemyPositionAfterCollision(enemy);
            }
        }
    }

    public void EndGame()
    {
        IsGameOver = true;

        // Stop the timer
        enemySpawnTimer.Stop();

        SaveScore();
    }

    private void SaveScore()
    {
        System.IO.File.AppendAllText("scores.txt", $"{DateTime.Now}: {Score}\n");
    }
}
