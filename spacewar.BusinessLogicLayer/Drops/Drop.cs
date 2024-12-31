using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer
{
    public abstract class Drop
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsCollected { get; set; }

        public Drop(int x, int y)
        {
            X = x;
            Y = y;
            IsCollected = false;
        }

        public abstract void ApplyEffect(Spaceship player);
    }

}
