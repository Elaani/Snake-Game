using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public readonly int length = 10;
        char headChar = ' ';
        char bodyChar = ' ';
        public static int currentX = 30;
        public static int currentY = 11;
        public static CircularQueue queue = new CircularQueue(10);
        public bool first = true;
        public bool invalidPoint = false;

        /// <summary>
        /// constructor for the snake, adds starting items to queue
        /// </summary>
        public Snake()
        {
            queue.Enqueue(new Position(21, 11));
            queue.Enqueue(new Position(22, 11));
            queue.Enqueue(new Position(23, 11));
            queue.Enqueue(new Position(24, 11));
            queue.Enqueue(new Position(25, 11));
            queue.Enqueue(new Position(26, 11));
            queue.Enqueue(new Position(27, 11));
            queue.Enqueue(new Position(28, 11));
            queue.Enqueue(new Position(29, 11));
            queue.Enqueue(new Position(30, 11));
        }

        /// <summary>
        /// calls all the methods required to make the snake move. 
        /// paints initial position if this is the first .move command, otherwise calls the rest
        /// </summary>
        /// <param name="dirX"></param>
        /// <param name="dirY"></param>
        public void Move(int dirX, int dirY)
        {
            if (first == true)
            {
                PaintInitialPosition();
                first = false;
            }
            else
            {
                PaintCurrentBodyPosition();
                PaintCurrentHeadPosition(dirX, dirY);
            }
        }

        /// <summary>
        /// paints the initial position of the snake on the screen
        /// </summary>
        private void PaintInitialPosition()
        {
            Console.SetCursorPosition(30, 11);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(headChar);

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(29 - i, 11);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(bodyChar);
            }
        }

        /// <summary>
        /// calls the methods to paint the curent body position
        /// </summary>
        private void PaintCurrentBodyPosition()
        {
            RemoveTail();
            UpdateBody();
        }

        /// <summary>
        /// updates the color of the previous head to be the color of the body
        /// </summary>
        private void UpdateBody()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Position update = queue.GetRear();
            int x = update.Left;
            int y = update.Top;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

        /// <summary>
        /// paints over the previous tail segment
        /// </summary>
        private void RemoveTail()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Position remove = new Position(0, 0);
            remove = queue.Dequeue();
            int x = remove.Left;
            int y = remove.Top;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }

        /// <summary>
        /// paints the new head position
        /// </summary>
        /// <param name="dirX"></param>
        /// <param name="dirY"></param>
        private void PaintCurrentHeadPosition(int dirX, int dirY)
        {
            currentY = currentY + dirY;
            currentX = currentX + dirX;

            Position add = new Position(currentX, currentY);
            queue.Enqueue(add);
            Console.SetCursorPosition(currentX, currentY);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(headChar);
        }

        /// <summary>
        /// returns true if snake touched itself, obstacle, or border
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public static bool IsGameOver (int x , int y, int dx, int dy)
        {
            if (x > 63 || x < 6) 
                return true;

            if (y > 21 || y < 4)
                return true;

            if (queue.ToString().Contains("(" + (x+dx) + "," + (y+dy) + ")"))
                return true;

            if ((x + dx) == 22 || (x + dx) == 23)
            {
                if ((y + dy) == 9)
                        return true;
                return false;
            }

            if ((x + dx) == 45 || (x + dx) == 46)
            {
                if ((y + dy) == 18)
                    return true;
                return false;
            }

            return false;
        }
    }
}
