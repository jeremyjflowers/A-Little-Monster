using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2020GameJam
{
    class Game
    {
        private Entity player;
        private Entity enemy;
        public static bool gameOver = false;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void End()
        {

        }

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }
    }
}
