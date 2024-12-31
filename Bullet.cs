using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    internal class Bullet
    {
        public int Speed { get; private set; }       
        public int Damage { get; private set; }     
        public int Direction { get; private set; }   
        public int PositionX { get; private set; }   
        public int PositionY { get; private set; }   
        public bool IsActive { get; private set; }

        public Bullet(int speed, int damage, int direction, int startX, int startY)
        {
            Speed = speed;
            Damage = damage;
            Direction = direction; 
            PositionX = startX;
            PositionY = startY;
            IsActive = true; 
        }

        public int Move(int x, int y)
        {
            if (!IsActive)
            {
                Console.WriteLine("Bullet is inactive. Cannot move.");
                return -1; 
            }

            // Yön ve hızına göre mermiyi hareket ettirir
            PositionY += Speed * Direction;
            Console.WriteLine($"Bullet moved to position ({PositionX}, {PositionY}).");

            // Oyun alanı sınırlarını kontrol eder
            if (PositionY < 0 || PositionY > 1000) // 1000, varsayılan oyun alanı yüksekliği
            {
                Console.WriteLine("Bullet left the game area and is now inactive.");
                IsActive = false; // Mermi oyun alanını terk ederse inaktif olur
            }

            return 0; // Başarılı hareket için 0 döner
        }

        public int OnHit()
        {
            if (!IsActive)
            {
                Console.WriteLine("Bullet is inactive. Cannot hit anything.");
                return -1; // Hata kodu
            }

            Console.WriteLine($"Bullet hit a target and dealt {Damage} damage!");
            IsActive = false; // Mermi isabet ettikten sonra inaktif olur
            return Damage; // Verilen hasar döner
        }
    }
}
