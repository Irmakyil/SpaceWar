using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace spacewar.BusinessLogicLayer
{
    public class Spaceship
    {
        public int Health { get;  set; }
        public int Damage { get;  set; }
        public int Speed { get;  set; }
        public List<Bullet> Bullets { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Spaceship(int health, int damage, int speed)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
            Bullets = new List<Bullet>();
            PositionX = 20;
            PositionY = 300;
        }
        public void Move(int horizontalDirection, int verticalDirection)
        {
            PositionX += horizontalDirection * Speed;
            PositionY += verticalDirection * Speed;
            
        }
        public bool CollidesWith(Rocks rock)
        {
            return false;
        }
        public void Shoot()
        {
            Bullets.Add(new Bullet(PositionX, PositionY, Damage, 1));
        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
        }
        public void Update()
        {
            Bullets.ForEach(b => b.Move());
            Bullets.RemoveAll(b => b.IsOutOfBounds());
        }
    }
}
