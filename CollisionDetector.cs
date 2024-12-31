using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    internal class CollisionDetector
    {
        // Oyuncu ve bir düşman arasındaki çarpışmayı kontrol eder
        public void CheckCollision(Spaceship player, Enemy enemy)
        {
            // Basit çarpışma kontrolü için bir mesafe ölçütü kullanılabilir
            int playerX = 50; // Varsayılan oyuncu X pozisyonu (gerçek pozisyon alınmalı)
            int playerY = 500; // Varsayılan oyuncu Y pozisyonu (gerçek pozisyon alınmalı)
            int enemyX = enemy.SpawnX;
            int enemyY = enemy.SpawnY;

            // Çarpışma algılama için basit mesafe kontrolü
            if (Math.Abs(playerX - enemyX) < 50 && Math.Abs(playerY - enemyY) < 50)
            {
                Console.WriteLine("Collision detected between player and enemy!");
                player.TakeDamage(enemy.Damage);
                enemy.TakeDamage(100); // Oyuncu çarpıştığında düşman yok ediliyor
            }
        }

        public void CheckBulletCollision(List<Bullet> bullets, List<Enemy> enemies)
        {
            foreach (var bullet in bullets)
            {
                if (!bullet.IsActive) continue; // İnaktif mermiler kontrol edilmez

                foreach (var enemy in enemies)
                {
                    // Çarpışma kontrolü: mermi ve düşmanın pozisyonlarını kıyasla
                    if (Math.Abs(bullet.PositionX - enemy.SpawnX) < 20 &&
                        Math.Abs(bullet.PositionY - enemy.SpawnY) < 20)
                    {
                        Console.WriteLine("Bullet hit an enemy!");

                        // Çarpışma etkileri
                        enemy.TakeDamage(bullet.Damage);
                        bullet.OnHit();

                        // Düşmanın sağlığı sıfırsa yok edilir
                        if (enemy.Health <= 0)
                        {
                            Console.WriteLine("Enemy destroyed!");
                            enemies.Remove(enemy);
                            break; // Liste değiştiği için döngüden çıkılır
                        }
                    }
                }
            }
        }
    }
}
