using System;

namespace Tetris
{
    public static class ShapeCellsZ
    {
        private const int DifferentRotations = 2;
        private const ConsoleColor Color = ConsoleColor.Green;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeZ_0();
                case 1:
                    return ShapeZ_1();
            }
            return null;
        }

        private static Square[,] ShapeZ_0()
        {
            Square[,] result = new Square[4, 4];
            result[1, 0] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeZ_1()
        {
            Square[,] result = new Square[4, 4];
            result[1, 3] = new Square(Color);
            result[2, 2] = new Square(Color);
            result[2, 3] = new Square(Color);
            result[3, 2] = new Square(Color);
            return result;
        }
    }
}
