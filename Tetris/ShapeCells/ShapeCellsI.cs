using System;

namespace Tetris
{
    public static class ShapeCellsI
    {
        private const int DifferentRotations = 2;
        private const ConsoleColor Color = ConsoleColor.Red;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeI_0();
                case 1:
                    return ShapeI_1();
            }
            return null;
        }

        private static Square[,] ShapeI_0()
        {
            Square[,] result = new Square[4, 4];
            result[0, 1] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[3, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeI_1()
        {
            Square[,] result = new Square[4, 4];
            result[1, 0] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[1, 3] = new Square(Color);
            return result;
        }
    }
}
