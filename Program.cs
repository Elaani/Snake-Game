using System;
using System.Diagnostics;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int dx = 1, dy = 0;

            bool gameActive = true; 
            ConsoleKeyInfo consoleKey;

            //start game
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();

            Map map = new Map(60, 20);
            map.Paint();

            Snake snake = new Snake();
            snake.Move(0, 0);

            do
            {
                if (Console.KeyAvailable)
                {
                    // get key and use it to set options
                    consoleKey = Console.ReadKey(true);
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.UpArrow: //UP
                            if (dx == 0 && dy == 1) //ensures the snake cannot go backwards on itself
                                break;
                            dx = 0;
                            dy = -1;
                            break;
                        case ConsoleKey.DownArrow: // DOWN
                            if (dx == 0 && dy == -1)//ensures the snake cannot go backwards on itself
                                break;
                            dx = 0;
                            dy = 1;
                            break;
                        case ConsoleKey.LeftArrow: //LEFT
                            if (dx == 1 && dy == 0)//ensures the snake cannot go backwards on itself
                                break;
                            dx = -1;
                            dy = 0;
                            break;
                        case ConsoleKey.RightArrow: //RIGHT
                            if (dx == -1 && dy == 0)//ensures the snake cannot go backwards on itself
                                break;
                            dx = 1;
                            dy = 0;
                            break;
                        case ConsoleKey.X: //END
                            gameActive = false;
                            break;
                        case ConsoleKey.Escape: //END
                            gameActive = false;
                            break;
                    }
                }

                //makes the snake move continuously in one direction until an arrow key is pressed
                snake.Move(dx, dy);
                map.PaintTime();

                if (Snake.IsGameOver(Snake.currentX, Snake.currentY, dx, dy))
                {
                    gameActive = false;
                }

                

                //delay for refresh, vertical refreshes at half the speed of horizontal because one square is two horizontal spaces and one vertical
                if (dx == 1 || dx == -1)
                {
                    System.Threading.Thread.Sleep(55);
                } else
                {
                    System.Threading.Thread.Sleep(110);
                }
            } while (gameActive);

            //Console.Clear();
            Console.Beep();
            Console.CursorLeft = 30;
            Console.CursorTop = 8;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("GAME OVER!");

            //spacing
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine();
            }
            }

        }
    }

