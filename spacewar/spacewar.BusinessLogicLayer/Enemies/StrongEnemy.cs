using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer.Enemies
{
    public class StrongEnemy : Enemy
    {
        public StrongEnemy(int spawnX, int spawnY) : base(spawnX, spawnY, 100, 2, 15) { }
        public override void Move()
        {
            // Strategic movement towards player
            SpawnX -= Speed;
        }
        public override void Attack(Spaceship player)
        {
            // Powerful but slower shooting
            Bullets.Add(new Bullet(SpawnX, SpawnY, Damage, -1));
        }
    }
}
