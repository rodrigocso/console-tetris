using System;

namespace Tetris
{
    public static class ShapeCellsS
    {
        private const int DifferentRotations = 2;
        private const ConsoleColor Color = ConsoleColor.Yellow;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeS_0();
                case 1:
                    return ShapeS_1();
            }
            return null;
        }

        private static Square[,] ShapeS_0()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[2, 0] = new Square(Color);
            result[2, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeS_1()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            result[3, 2] = new Square(Color);
            return result;
        }
    }
}
