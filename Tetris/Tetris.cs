using System;
using System.Threading;

namespace Tetris
{
    public class Tetris
    {
        private const int TimeStep = 30;
        private const string GameOverMsg = "        GAME OVER!        ";
        private const string GameTitle = "TETRIS";
        private Board board = new Board(2, Console.WindowWidth / 2 - 5);

        public void StartGame()
        {
            Console.Title = GameTitle;
            DisplayStartScreen();

            while (!board.IsGameOver())
            {
                board.CheckUserInput();
                board.Update();
                board.Draw();
                Thread.Sleep(TimeStep);
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - GameOverMsg.Length / 2, Console.WindowHeight / 2);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(GameOverMsg);
            Console.ReadLine();
        }

        private void DisplayStartScreen()
        {
            int x = Console.WindowWidth / 2 - 29;
            int y = Console.WindowHeight / 2 - 3;

            Console.WriteLine("PG1: Programmer's Choice Project");
            Console.WriteLine("Author: Rodrigo Correa da Silva Oliveira");

            Console.SetCursorPosition(x, y);
            Console.Write(@" ______   ______     ______   ______     __     ______    ");
            Console.SetCursorPosition(x, ++y);
            Console.Write(@"/\__  _\ /\  ___\   /\__  _\ /\  == \   /\ \   /\  ___\   ");
            Console.SetCursorPosition(x, ++y);
            Console.Write(@"\/_/\ \/ \ \  __\   \/_/\ \/ \ \  __<   \ \ \  \ \___  \  ");
            Console.SetCursorPosition(x, ++y);
            Console.Write(@"   \ \_\  \ \_____\    \ \_\  \ \_\ \_\  \ \_\  \/\_____\ ");
            Console.SetCursorPosition(x, ++y);
            Console.Write(@"    \/_/   \/_____/     \/_/   \/_/ /_/   \/_/   \/_____/ ");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 12, y + 2);
            Console.WriteLine("Press any key to start!");
            Console.ReadLine();
        }
    }
}
