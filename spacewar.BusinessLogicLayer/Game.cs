                        using spacewar.BusinessLogicLayer.Enemies;
                        using spacewar.BusinessLogicLayer.Utilities;
                        using spacewar.BusinessLogicLayer;
                        using System.Collections.Generic;
                        using System.Timers;
                        using System;
                        using System.Net.Security;

                        public class Game
                        {
                    
                            public Spaceship Player { get; private set; }
                            public List<Enemy> Enemy1 { get; private set; }
                            public List<Enemy> Enemy2 { get; private set; }
                            public List<Enemy> Enemy3 { get; private set; }
                            public List<Enemy> Enemy4 { get; private set; }
                            public List<Drop> Health { get; private set; }
                            public List<Drop> Speeds { get; private set; }
                            public List<Drop> Damages { get; private set; }
                            public List<Rocks> rocks { get; private set; }
                            public bool IsGameOver { get; private set; }
                            public int Score { get; private set; }
                            private Timer enemySpawnTimer;
                            private Timer powerUpSpawnTimer;
                            private Timer rockSpawnTimer;


                            private const int WindowWidth = 800;
                            private const int WindowHeight = 600;

                            public Game()
                            {
                                Enemy1 = new List<Enemy>();
                                Enemy2 = new List<Enemy>();
                                Enemy3 = new List<Enemy>();
                                Enemy4 = new List<Enemy>();
                                Health = new List<Drop>();
                                Speeds = new List<Drop>();
                                Damages = new List<Drop>();
                                rocks = new List<Rocks>();

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


                                powerUpSpawnTimer = new Timer(8000);
                                powerUpSpawnTimer.Elapsed += SpawnPowerUpOnTimer;
                                powerUpSpawnTimer.AutoReset = true;
                                powerUpSpawnTimer.Start();


                                rockSpawnTimer = new Timer(10000);
                                rockSpawnTimer.Elapsed += SpawnRocksOnTimer;
                                rockSpawnTimer.AutoReset = true;
                                rockSpawnTimer.Start();

                            IsGameOver = false;
                                Score = 0;
                            }

                            private void SpawnEnemies()
                            {
                                Random random = new Random();
                                Enemy1.Add(new BasicEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                Enemy2.Add(new FastEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                Enemy3.Add(new StrongEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                Enemy4.Add(new BossEnemy(WindowWidth, random.Next(0, WindowHeight)));
                            }

                            private void SpawnEnemyOnTimer(object sender, ElapsedEventArgs e)
                            {
                                Random random = new Random();
                                int enemyType = random.Next(0, 4);

                                switch (enemyType)
                                {
                                    case 0:
                                        Enemy1.Add(new BasicEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                        break;
                                    case 1:
                                        Enemy2.Add(new FastEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                        break;
                                    case 2:
                                        Enemy3.Add(new StrongEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                        break;
                                    case 3:
                                        Enemy4.Add(new BossEnemy(WindowWidth, random.Next(0, WindowHeight)));
                                        break;
                                }
                            }

                            private void SpawnPowerUp(object sender, ElapsedEventArgs e)
                            {
                                Random random = new Random();
                                Health.Add(new HealthDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                Speeds.Add(new SpeedDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                Damages.Add(new DamageDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                            }

                            private void SpawnPowerUpOnTimer(object sender, ElapsedEventArgs e)
                            {
                                Random random = new Random();
                                int dropType = random.Next(0, 3);

                                switch (dropType)
                                {
                                    case 0:
                                        Health.Add(new HealthDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                        break;
                                    case 1:
                                        Speeds.Add(new SpeedDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                        break;
                                    case 2:
                                        Damages.Add(new DamageDrop(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                        break;
                                }
                            }

                        private void SpawnRock(object sender, ElapsedEventArgs e)
                        {
                            Random random = new Random();
                            rocks.Add(new Rocks(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                        }

                        private void SpawnRocksOnTimer(object sender, ElapsedEventArgs e)
                        {
                            Random random = new Random();
                            int rockType = random.Next(0, 1);

                            switch (rockType)
                            {
                                case 0:
                                    rocks.Add(new Rocks(random.Next(0, WindowWidth), random.Next(0, WindowHeight)));
                                    break;
                            }
                        }
                        public void UpdateGame()
                            {
                                Player.Update();
                                var currentEnemy1 = new List<Enemy>(Enemy1);
                                var currentEnemy2 = new List<Enemy>(Enemy2);
                                var currentEnemy3 = new List<Enemy>(Enemy3);
                                var currentEnemy4 = new List<Enemy>(Enemy4);
                                var currentHealth = new List<Drop>(Health);
                                var currentSpeed = new List<Drop>(Speeds);
                                var currentDamage = new List<Drop>(Damages);
                                var currentRock = new List<Rocks>(rocks);

                            foreach (var enemy in currentEnemy1)
                                {
                                    enemy.Move();
                                }
                                foreach (var enemy in currentEnemy2)
                                {
                                    enemy.Move();
                                }
                                foreach (var enemy in currentEnemy3)
                                {
                                    enemy.Move();
                                }
                                foreach (var enemy in currentEnemy4)
                                {
                                    enemy.Move();
                                }
                           foreach (var rock in rocks)
                              {
                            rock.MoveDown(2);
                              }



                    CheckCollisions();

                                Enemy1.RemoveAll(e => e.Health <= 0);
                                Enemy2.RemoveAll(e => e.Health <= 0);
                                Enemy3.RemoveAll(e => e.Health <= 0);
                                Enemy4.RemoveAll(e => e.Health <= 0);

                                Health.RemoveAll(e => e.IsCollected);
                                Speeds.RemoveAll(e => e.IsCollected);
                                Damages.RemoveAll(e => e.IsCollected);

                        
                            if (Player.Health <= 0)
                                {
                                    EndGame();
                                }
                            }
                            private void AdjustEnemyPositionAfterCollision(Enemy enemy)
                            {
                                if (enemy == null) return;
       
                                if (enemy.SpawnX < Player.PositionX)
                                {
                                    enemy.SpawnX -= 10; 
                                }
                                else
                                {
                                    enemy.SpawnX += 10; 
                                }

                                if (enemy.SpawnY < Player.PositionY)
                                {
                                    enemy.SpawnY -= 10; 
                                }
                                else
                                {
                                    enemy.SpawnY += 10;
                                }
                            }
                            private void CheckCollisions()
                            {
                                CollisionDetector collisionDetector = new CollisionDetector();

                                foreach (var bullet in Player.Bullets)
                                {
                                    foreach (var enemy in Enemy1)
                                    {
                                        if (collisionDetector.CheckBulletCollision(bullet, enemy))
                                        {
                                            bullet.OnHit();
                                            enemy.TakeDamage(bullet.Damage);
                                            Score += 10;
                                        }
                                    }
                                }

                                foreach (var enemy in Enemy1)
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

                                foreach (var enemy in Enemy1)
                                {
                                    if (collisionDetector.CheckCollision(Player, enemy))
                                    {
                                        Player.TakeDamage(enemy.Damage);
                                        AdjustEnemyPositionAfterCollision(enemy);
                                    }
                                }


                                foreach (var bullet in Player.Bullets)
                                {
            
                                    foreach (var enemy in Enemy2)
                                    {
                                        if (collisionDetector.CheckBulletCollision(bullet, enemy))
                                        {
                                            bullet.OnHit();
                                            enemy.TakeDamage(bullet.Damage);
                                            Score += 10;
                                        }
                                    }
                                }

                                foreach (var enemy in Enemy2)
                                {
                                    enemy.Attack(Player);
                                    foreach (var bullet in enemy.Bullets)
                                    {
                                        if (collisionDetector.CheckBulletCollision(bullet, Player))
                                        {
                                            bullet.OnHit();
                                            Player.TakeDamage(bullet.Damage);
                                        }
                                    }
                                }

                                foreach (var enemy in Enemy2)
                                {
                                    enemy.Attack(Player);
                                    if (collisionDetector.CheckCollision(Player, enemy))
                                    {
                
                                        Player.TakeDamage(enemy.Damage);
                                        AdjustEnemyPositionAfterCollision(enemy);
                
                                    }
                                }

                                foreach (var bullet in Player.Bullets)
                                {
                                    foreach (var enemy in Enemy3)
                                    {
                
                                        if (collisionDetector.CheckBulletCollision(bullet, enemy))
                                        {
                                            bullet.OnHit();
                                            enemy.TakeDamage(bullet.Damage);
                                            Score += 10;
                                        }
                                    }
                                }

                                foreach (var enemy in Enemy3)
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

                                foreach (var enemy in Enemy3)
                                {
                                    if (collisionDetector.CheckCollision(Player, enemy))
                                    {
                                        Player.TakeDamage(enemy.Damage);
                                        AdjustEnemyPositionAfterCollision(enemy);
                                    }
                                }

                                foreach (var bullet in Player.Bullets)
                                {
                                    foreach (var enemy in Enemy4)
                                    {
                                        if (collisionDetector.CheckBulletCollision(bullet, enemy))
                                        {
                                            bullet.OnHit();
                                            enemy.TakeDamage(bullet.Damage);
                                            Score += 10;
                                        }
                                    }
                                }

                                foreach (var enemy in Enemy4)
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

                                foreach (var enemy in Enemy4)
                                {
                                    if (collisionDetector.CheckCollision(Player, enemy))
                                    {
                                        Player.TakeDamage(enemy.Damage);
                                        AdjustEnemyPositionAfterCollision(enemy);
                                    }
                                }

                                foreach (var rock in rocks)
                                {
                                     if (Player.CollidesWith(rock))
                                     {
                                           Player.TakeDamage(rock.Damage);
                                     }

                                }

                    foreach (var powerUp in Health)
                                {
                                    if (collisionDetector.CheckCollision(Player, powerUp))
                                    {
                                        powerUp.ApplyEffect(Player);
                                        powerUp.IsCollected = true;
                                    }
                                }
                                foreach (var powerUp in Speeds)
                                {
                                    if (collisionDetector.CheckCollision(Player, powerUp))
                                    {
                                        powerUp.ApplyEffect(Player);
                                        powerUp.IsCollected = true;
                                    }
                                }
                                foreach (var powerUp in Damages)
                                {
                                    if (collisionDetector.CheckCollision(Player, powerUp))
                                    {
                                        powerUp.ApplyEffect(Player);
                                        powerUp.IsCollected = true;
                                    }
                                }
  

                            }
                            public void EndGame()
                            {
                                IsGameOver = true;

                                enemySpawnTimer.Stop();
                                powerUpSpawnTimer.Stop();
                                rockSpawnTimer.Stop();


                                SaveScore();
                            }

                            private void SaveScore()
                            {
                                System.IO.File.AppendAllText("scores.txt", $"{DateTime.Now}: {Score}\n");
                            }
                        }
