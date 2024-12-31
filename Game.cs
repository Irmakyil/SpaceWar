using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{

    internal class Game
    {
        public string SpaceshipPlayer { get; set; }
        public string Enemy { get; set; }
        private List<string> enemies; 
        public bool isGameOver { get; set; }
        public bool IsValid { get; set; }
        private Stopwatch stopwatch;
        //public int StartGame(string SpaceshipPlayer, string Enemy)
        //{
        //    SpaceshipPlayer = spaceshipPlayer;
        //    Enemy = enemy;
        //    enemies = new List<string> { Enemy }; // Başlangıçta bir düşman ekleniyor
        //    stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    isGameOver = false;
        //    IsValid = true;


        //}

        //public int UpdateGame()
        //{

        //}
        //public int CheckCollisions()
        //{

        //}

        public void EndGame()
        {
            isGameOver = true;
            stopwatch.Stop();
        }



    }
}
