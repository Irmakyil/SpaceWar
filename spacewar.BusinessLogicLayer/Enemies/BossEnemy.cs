using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer.Enemies
{
    public class BossEnemy : Enemy
    {
        public BossEnemy(int spawnX, int spawnY) : base(spawnX, spawnY, 200, 1, 25) { }
        public override void Move()
        {
            SpawnX -= Speed;
        }
        public override void Attack(Spaceship player)
        {
            for (int i = -2; i <= 2; i++)
            {
                Bullets.Add(new Bullet(SpawnX, SpawnY + i * 20, Damage, -1));
            }
        }
    }
}
