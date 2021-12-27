using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Snake
{
    class Map
    {
        Stopwatch stopwatch = new Stopwatch();
        public int x;
        public int y;
        public int Top = 3;
        public int Left = 5;

        /// <summary>
        /// constructor for map
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Map(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// paints initial board state
        /// </summary>
        public void Paint()
        {
            Console.WriteLine("");
            Console.CursorLeft = Left + 25;
            Console.WriteLine("Snake Game");
            Console.CursorTop = Top;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < y; i++)
            {
                Console.CursorLeft = Left;
                Console.WriteLine(new string(' ', x));
            }

            PaintObstacle();

            void PaintObstacle()
            {
                Console.CursorTop = 9;
                Console.CursorLeft = 22;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("  ");
                Console.CursorTop = 18;
                Console.CursorLeft = 45;
                Console.WriteLine("  ");
            }
        }

        /// <summary>
        /// updates the time counter on each tick
        /// </summary>
        public void PaintTime()
        {
            stopwatch.Start();

            Console.CursorTop = 24;
            Console.CursorLeft = 66;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorLeft = Left + 20;
            Console.WriteLine("Time: " + stopwatch.Elapsed);
        }
    }

    
}
