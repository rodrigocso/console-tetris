namespace Tetris
{
    public class Grid
    {
        private int rows, columns;
        private int top, left;
        private Square[,] cells;

        public Grid(int top, int left, int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.top = top;
            this.left = left;
            cells = new Square[rows, columns];
        }

        public Grid(int top, int left, Square[,] cells)
        {
            this.top = top;
            this.left = left;
            this.cells = cells;
            rows = cells.GetLength(0);
            columns = cells.GetLength(1);
        }

        public Grid(Grid grid, Square[,] cells)
        {
            rows = grid.Rows;
            columns = grid.Columns;
            top = grid.Top;
            left = grid.Left;
            this.cells = cells;
        }

        public int Top { get { return top; } }
        public int Left { get { return left; } }
        public int Rows { get { return rows; } }
        public int Columns { get { return columns; } }
        public void SetCells(Square[,] cells) { this.cells = cells; }

        public Square[,] GetCells() { return cells; }

        public void Draw()
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    if (cells[row, col] != null)
                        cells[row, col].Draw(col + Left, row + Top);
        }

        public void Draw(Grid board)
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    if (cells[row, col] != null)
                        if (row + Top - board.Top >= 0)
                            cells[row, col].Draw(col + Left, row + Top);
        }

        public void Draw(int x, int y)
        {
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                    if (cells[row, col] != null)
                        cells[row, col].Draw(col + x, row + y);
        }

        public void MoveLeft() { left--; }
        public void MoveRight() { left++; }
        public void MoveDown() { top++; }

        public void MergeGrid(Grid g)
        {
            if (g.Rows > Rows || g.Columns > Columns)
                return;

            for (int row = 0; row < g.Rows; row++)
                for (int column = 0; column < g.Columns; column++)
                    if (g.cells[row, column] != null)
                        cells[row + g.Top - Top, column + g.Left - Left] = g.cells[row, column];
        }
    }
}