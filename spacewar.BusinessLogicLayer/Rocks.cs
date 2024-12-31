using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace spacewar.BusinessLogicLayer
{
    public class Rocks
    {
        public int X { get; set; } 
        public int Y { get; set; } 
        public int Damage { get; set; }
        public bool IsDestroyed { get; private set; } = false;

        private static Random random = new Random();

        public  Rocks(int x, int y)
        {
            X = x;
            Y = y;


        }
        public void MoveDown(int speed)
        {
            X += speed;
        }

        public bool IsOutOfBounds(int WindowWidth)
        {
            return IsDestroyed || X < 0 || Y > 800;
        }

        public void OnHit()
        {
            IsDestroyed = true;
        }
    }
}
