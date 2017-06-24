using System;

namespace Tetris
{
    public class Square
    {
        private ConsoleColor color;

        public Square(ConsoleColor color) { this.color = color; }

        public void Draw(int x, int y)
        {
            if (y < 0 || y >= Console.WindowHeight)
                return;

            if (x < 0 || x >= Console.WindowWidth)
                return;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write('@');
        }
    }
}