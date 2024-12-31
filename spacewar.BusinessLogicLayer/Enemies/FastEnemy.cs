using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer.Enemies
{
    public class FastEnemy : Enemy
    {
        public FastEnemy(int spawnX, int spawnY) : base(spawnX, spawnY, 30, 4, 3) 
        {
          
        }
        public override void Move()
        {
            SpawnX -= Speed;
        }
        public override void Attack(Spaceship player)
        {

            //if (new Random().Next(10) < 3)
            //{
            //    Bullets.Add(new Bullet(SpawnX, SpawnY, Damage, -1));
            //}
        }
    }
}
