using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer
{
    public class SpeedDrop : Drop
    {
        public SpeedDrop(int x, int y) : base(x, y) { }

        public override void ApplyEffect(Spaceship player)
        {
            player.Speed += 10;
        }
    }
}
