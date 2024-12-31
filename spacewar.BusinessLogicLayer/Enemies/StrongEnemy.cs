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
            SpawnX -= Speed;
        }
        public override void Attack(Spaceship player)
        {
            Bullets.Add(new Bullet(SpawnX, SpawnY, Damage, -1));
        }
    }
}
