using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spacewar.BusinessLogicLayer.Enemies;

namespace spacewar.BusinessLogicLayer.Utilities
{
    public class CollisionDetector
    {
        public bool CheckBulletCollision(Bullet bullet, Enemy enemy)
        {
            // Simple collision detection based on proximity
            return Math.Abs(bullet.PositionX - enemy.SpawnX) < 20 &&
                   Math.Abs(bullet.PositionY - enemy.SpawnY) < 20;
        }
        public bool CheckBulletCollision(Bullet bullet, Spaceship player)
        {
            // Simple collision detection based on proximity
            return Math.Abs(bullet.PositionX - player.PositionX) < 20 &&
                   Math.Abs(bullet.PositionY - player.PositionY) < 20;
        }
        public bool CheckCollision(Spaceship player, Enemy enemy)
        {
            // Simple collision detection based on proximity
            return Math.Abs(player.PositionX - enemy.SpawnX) < 20 &&
                   Math.Abs(player.PositionY - enemy.SpawnY) < 20;
        }
    }
}