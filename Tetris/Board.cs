using System;

namespace Tetris
{
    public class Board
    {
        private const float SpeedPerLevel = 0.025f;
        public const int Height = 20;
        public const int Width = 10;
        private const ConsoleColor BorderColor = ConsoleColor.Gray;
        private const int LinesPerLevel = 10;
        private const int NumberOfShapes = 7;
        private int lines = 0, score = 0, level = 1;
        private float dropSpeed = 0.1f;
        private bool isGameOver = false;
        private Grid grid;
        private Shape currShape;
        private Shape nextShape;
        private Random prng = new Random();

        public Board(int top, int left)
        {
            grid = new Grid(top, left, Height, Width);
            currShape = new Shape(grid, (Shape.Type)(prng.Next(0, NumberOfShapes)));
            nextShape = new Shape(grid, (Shape.Type)(prng.Next(0, NumberOfShapes)));
        }

        public bool IsGameOver() { return isGameOver; }

        public void CheckUserInput()
        {
            ConsoleKey k;

            if (Console.KeyAvailable)
            {
                k = Console.ReadKey().Key;

                switch (k)
                {
                    case ConsoleKey.LeftArrow:
                        currShape.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        currShape.MoveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        currShape.Rotate();
                        break;
                    case ConsoleKey.DownArrow:
                        currShape.MoveDown();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Update()
        {
            ClearCompletedLines();

            if (currShape.IsDead)
            {
                if (CurrShapeIsOutOfBoard())
                {
                    isGameOver = true;
                    return;
                }
                grid.MergeGrid(currShape.Grid);
                currShape = nextShape;
                nextShape = new Shape(grid, (Shape.Type)(prng.Next(0, NumberOfShapes)));
            }

            currShape.MoveDown(dropSpeed);
        }

        private bool CurrShapeIsOutOfBoard()
        {
            for (int row = 0; row < currShape.Grid.Rows; row++)
                for (int col = 0; col < currShape.Grid.Columns; col++)
                    if (currShape.Grid.GetCells()[row, col] != null)
                        if (row + currShape.Grid.Top - grid.Top < 0)
                            return true;

            return false;
        }

        private void ClearCompletedLines()
        {
            int squaresInRow = 0;

            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                    if (grid.GetCells()[row, col] != null)
                        squaresInRow++;

                if (squaresInRow == 10)
                {
                    grid.SetCells(RemoveLineFromGrid(row, grid.GetCells()));
                    ComputeLevelAndScore();
                }

                squaresInRow = 0;
            }
        }

        private Square[,] RemoveLineFromGrid(int row, Square[,] cells)
        {
            Square[,] result = new Square[cells.GetLength(0), cells.GetLength(1)];

            for (int r = row; r > 0; r--)
                for (int c = 0; c < cells.GetLength(1); c++)
                    result[r, c] = cells[r - 1, c];

            for (int r = row + 1; r < cells.GetLength(0); r++)
                for (int c = 0; c < cells.GetLength(1); c++)
                    result[r, c] = cells[r, c];

            return result;
        }

        private void ComputeLevelAndScore()
        {
            lines++;
            score += level * 100;
            if (lines % LinesPerLevel == 0)
            {
                level++;
                dropSpeed += SpeedPerLevel;
            }
        }

        public void Draw()
        {
            Console.Clear();
            DrawBorders();
            grid.Draw();
            DisplayData();
            currShape.Draw(grid);
            nextShape.Draw(grid.Left + grid.Columns + 3, grid.Top + grid.Rows / 2 - 2);
        }

        private void DrawBorders()
        {
            Console.ForegroundColor = BorderColor;
            DrawBox(grid.Left - 1, grid.Top - 1, Width + 2, Height + 2, true);

            Console.SetCursorPosition(grid.Left + grid.Columns + 2, grid.Top + grid.Rows / 2 - 4);
            Console.Write("NEXT:");
            DrawBox(grid.Left + grid.Columns + 2, grid.Top + grid.Rows / 2 - 3, 6, 6, false);
        }

        private void DisplayData()
        {
            int x = grid.Left + Width + 2;
            int y = grid.Top;

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(x, y);
            Console.Write("LEVEL: {0}", level);
            Console.SetCursorPosition(x, ++y);
            Console.Write("LINES: {0:#,##0}", lines);
            Console.SetCursorPosition(x, ++y);
            Console.Write("SCORE: {0:#,##0}", score);
        }

        /// <summary>
        /// Draws a box (or "window") within the console.
        /// </summary>
        /// <param name="left">The x coordinate of the top-left of the box</param>
        /// <param name="top">The y coordinate of the top-left of the box</param>
        /// <param name="width">The width of the box</param>
        /// <param name="height">The height of the box</param>
        /// <param name="dbl">Use single or double lines for border</param>
        private static void DrawBox(int left, int top, int width, int height, bool dbl = false)
        {
            string singleLine = "┌─┐│└┘";
            string doubleLine = "╔═╗║╚╝";
            string set = dbl ? doubleLine : singleLine;

            Console.SetCursorPosition(left, top);
            Console.Write(set[0]);

            for (int col = 0; col < width - 2; col++)
            {
                Console.Write(set[1]);
            }

            Console.Write(set[2]);

            int x = left + width - 1;
            int y = top + 1;

            for (int row = 0; row < height - 2; row++, y++)
            {
                Console.SetCursorPosition(left, y);
                Console.Write(set[3]);

                Console.SetCursorPosition(x, y);
                Console.Write(set[3]);
            }

            y = top + height - 1;

            Console.SetCursorPosition(left, y);
            Console.Write(set[4]);

            for (int col = 0; col < width - 2; col++)
            {
                Console.Write(set[1]);
            }

            Console.Write(set[5]);
        }
    }
}