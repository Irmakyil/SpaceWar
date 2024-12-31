using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    internal class Spaceship
    {
        public int Health { get; private set; } 
        public int Damage { get; private set; } 
        public int Speed { get; private set; }  
        private List<string> Bullets;           

        public Spaceship(int health, int damage, int speed)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
            Bullets = new List<string>(); 
        }
        //public int Move(int x, int y)
        //{

        //}

        //public int Shoot()
        //{


        //}

        public int TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"Spaceship took {amount} damage. Remaining health: {Health}");

            if (Health <= 0)
            {
                Console.WriteLine("Spaceship destroyed!");
                return -1; 
            }

            return Health;
        }


           

    }
}
