using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer
{
    public class HealthDrop : Drop
    {
        public HealthDrop(int x, int y) : base(x, y) { }

        public override void ApplyEffect(Spaceship player)
        {
            player.Health += 20; 
        }
    }

}
