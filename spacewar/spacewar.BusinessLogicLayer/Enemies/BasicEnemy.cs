using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer.Enemies
{
    public class BasicEnemy : Enemy
    {
        public BasicEnemy(int spawnX, int spawnY) : base(spawnX, spawnY, 50, 3, 1) { }

        public override void Move()
        {
            // Simple linear movement towards player
            SpawnX -= Speed;
        }

        public override void Attack(Spaceship player)
        {
            // Simple shooting mechanism
            Bullets.Add(new Bullet(SpawnX, SpawnY, Damage, -1)); // Left-moving bullet
        }
    }
}
