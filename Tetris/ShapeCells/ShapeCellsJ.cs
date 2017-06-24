using System;

namespace Tetris
{
    public static class ShapeCellsJ
    {
        private const int DifferentRotations = 4;
        private const ConsoleColor Color = ConsoleColor.White;

        public static Square[,] Generate(int rotation)
        {
            rotation = rotation % DifferentRotations;

            switch (rotation)
            {
                case 0:
                    return ShapeJ_0();
                case 1:
                    return ShapeJ_1();
                case 2:
                    return ShapeJ_2();
                case 3:
                    return ShapeJ_3();
            }
            return null;
        }

        private static Square[,] ShapeJ_0()
        {
            Square[,] result = new Square[4, 4];
            result[0, 2] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[2, 2] = new Square(Color);
            result[2, 1] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeJ_1()
        {
            Square[,] result = new Square[4, 4];
            result[0, 1] = new Square(Color);
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[1, 3] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeJ_2()
        {
            Square[,] result = new Square[4, 4];
            result[0, 2] = new Square(Color);
            result[0, 3] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[2, 2] = new Square(Color);
            return result;
        }

        private static Square[,] ShapeJ_3()
        {
            Square[,] result = new Square[4, 4];
            result[1, 1] = new Square(Color);
            result[1, 2] = new Square(Color);
            result[1, 3] = new Square(Color);
            result[2, 3] = new Square(Color);
            return result;
        }
    }
}
