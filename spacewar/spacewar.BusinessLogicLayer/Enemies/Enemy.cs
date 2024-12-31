using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace spacewar.BusinessLogicLayer.Enemies
{
    public abstract class Enemy
    {
        public int Health { get; protected set; }
        public int Speed { get; protected set; }
        public int Damage { get; protected set; }
        public int SpawnX { get; set; }
        public int SpawnY { get; set; }
        public List<Bullet> Bullets { get; set; }

        public Enemy(int spawnX, int spawnY, int health, int speed, int damage)
        {
            SpawnX = spawnX;
            SpawnY = spawnY;
            Health = health;
            Speed = speed;
            Damage = damage;
            Bullets = new List<Bullet>();
        }
        public abstract void Move();
        public abstract void Attack(Spaceship player);
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Destroy();
            }
        }
        protected virtual void Destroy()
        {
        }
    }
}
