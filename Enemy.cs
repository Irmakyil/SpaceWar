using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    internal class Enemy
    {
        public int Health { get; private set; }  
        public int Speed { get; private set; }   
        public int Damage { get; private set; }  
        public int SpawnX { get; private set; }  
        public int SpawnY { get; private set; }

        public Enemy(int health, int speed, int damage, int spawnX, int spawnY)
        {
            Health = health;
            Speed = speed;
            Damage = damage;
            SpawnX = spawnX;
            SpawnY = spawnY;
        }

        public int Move(int x, int y)
        {
            SpawnX += x * Speed;
            SpawnY += y * Speed;

            return 0;
        }

        //public int Attack(int x, int y)
        //{

        //}

        public int TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"Enemy took {amount} damage. Remaining health: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine("Enemy destroyed!");
                return Destroy(); // Sağlık 0 veya altına düştüğünde yok edilir
            }

            return Health;
        }

        public int Destroy()
        {
            Console.WriteLine("Enemy has been removed from the game.");
            return -1;
        }

        //enemy türleri tanımlanacak!!!!

        public static Enemy CreateBasicEnemy(int spawnX, int spawnY)
        {
            return new Enemy(health: 50, speed: 2, damage: 10, spawnX: spawnX, spawnY: spawnY);
        }
        public static Enemy CreateFastEnemy(int spawnX, int spawnY)
        {
            return new Enemy(health: 30, speed: 4, damage: 5, spawnX: spawnX, spawnY: spawnY);
        }

        public static Enemy CreateStrongEnemy(int spawnX, int spawnY)
        {
            return new Enemy(health: 100, speed: 1, damage: 20, spawnX: spawnX, spawnY: spawnY);
        }

        public static Enemy CreateBossEnemy(int spawnX, int spawnY)
        {
            return new Enemy(health: 30, speed: 4, damage: 5, spawnX: spawnX, spawnY: spawnY);
        }



    }
}
