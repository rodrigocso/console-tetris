using System;

namespace Tetris
{
    public static class ShapeCellsT
    {
        private const int DifferentRotations = 4;
        private const ConsoleColor Color = ConsoleColor.Blue;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeT_0();
                case 1:
                    return ShapeT_1();
                case 2:
                    return ShapeT_2();
                case 3:
                    return ShapeT_3();
            }
            return null;
        }

        private static Square[,] ShapeT_0()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[2, 0] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeT_1()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            result[3, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeT_2()
        {
            Square[,] result = new Square[4, 4];
            result[2, 0] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[2, 2] = new Square(Color);
            result[3, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeT_3()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[2, 0] = new Square(Color);
            result[2, 1] = new Square(Color);
            result[3, 1] = new Square(Color);
            return result;
        }
    }
}
