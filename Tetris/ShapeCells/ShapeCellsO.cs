using System;

namespace Tetris
{
    public static class ShapeCellsO
    {
        private const int DifferentRotations = 1;
        private const ConsoleColor Color = ConsoleColor.Cyan;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);

            return result;
        }
    }
}
