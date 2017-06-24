using System;

namespace Tetris
{
    public static class ShapeCellsL
    {
        private const int DifferentRotations = 4;
        private const ConsoleColor Color = ConsoleColor.Magenta;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeL_0();
                case 1:
                    return ShapeL_1();
                case 2:
                    return ShapeL_2();
                case 3:
                    return ShapeL_3();
            }
            return null;
        }

        private static Square[,] ShapeL_0()
        {
            Square[,] result = new Square[4, 4];
            result[0, 1] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeL_1()
        {
            Square[,] result = new Square[4, 4];
            result[1, 0] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[2, 0] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeL_2()
        {
            Square[,] result = new Square[4, 4];
            result[0, 0] = new Square(Color);
            result[0, 1] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeL_3()
        {
            Square[,] result = new Square[4, 4];
            result[0, 2] = new Square(Color);
            result[1, 0] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            return result;
        }
    }
}
