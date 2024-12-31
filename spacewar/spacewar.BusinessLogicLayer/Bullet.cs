using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacewar.BusinessLogicLayer
{
    public class Bullet
    {
        public int Speed { get; private set; }
        public int Damage { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Direction { get; private set; } // 1 for player, -1 for enemy
        public bool IsDestroyed { get; private set; } = false;

        public Bullet(int x, int y, int damage, int direction)
        {
            PositionX = x;
            PositionY = y;
            Damage = damage;
            Direction = direction;
            Speed = 10;
        }

        public void Move()
        {
            if (!IsDestroyed)
            {
                PositionX += Speed * Direction;
            }
        }

        public void OnHit()
        {
            // Mark the bullet as destroyed
            IsDestroyed = true;
        }

        public bool IsOutOfBounds()
        {
            // Check if bullet is outside game area or destroyed
            return IsDestroyed || PositionX < 0 || PositionX > 800;
        }
    }
}