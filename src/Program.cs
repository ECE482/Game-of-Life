using System;
using System.Threading;
using GameOfLife;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GameOfLifeSession game = new GameOfLifeSession();
            Console.Title = "Game Of Life!";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome, to the GAME OF LIFE!!! :)\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Set Simulation Options ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your number then press enter to advance.\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the number of rows 1 - 30:\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            game.Rows = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the number of columns 1 - 30:\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            game.Columns = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter refresh rate in seconds (1-3); ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            game.CycleTime = 1000 * double.Parse(Console.ReadLine());

            game.NextCycle += Game_Update;

            Console.CursorVisible = false;
            Console.ReadLine();
            Console.CancelKeyPress += (sender, args) =>
            {
                game.Stop();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n Thank you for playing!");

            };
            game.Start();

            Thread.Sleep(Timeout.Infinite);
        }

        private static void Game_Update(GameOfLifeSession game, Status[,] nextCycle)
        {
            Console.Clear();
            Console.Write("Clear\n");

            for (int row = 0; row < game.Rows; row++)
            {
                for (int column = 0; column < game.Columns; column++)
                {
                    Status cell = nextCycle[row, column];
                    Console.ForegroundColor = cell == Status.Alive ?
                    ConsoleColor.Green : ConsoleColor.DarkRed;

                    Console.Write(cell == Status.Alive ? "*" : ".");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nResult of Cycle:           " + game.CycleCounter);
            Console.WriteLine("\nNumber of cells alive:     " + game.AliveCounter);
            Console.WriteLine("PRESS CTRL + C TO END SIMULATION");
        }

    }
}