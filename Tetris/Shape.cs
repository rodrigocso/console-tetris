namespace Tetris
{
    public class Shape
    {
        public enum Type { I, J, L, O, S, T, Z };
        private float top;
        private int rotation = 0;
        private bool isDead = false;
        private Type type;
        private Grid grid;
        private Grid boardGrid;

        public Shape(Grid boardGrid, Type type)
        {
            this.boardGrid = boardGrid;
            this.type = type;
            grid = new Grid(boardGrid.Top - 3, boardGrid.Left + 3, GenerateShapeCells(type, rotation));
            top = grid.Top;
        }

        public bool IsDead { get { return isDead; } }
        public Grid Grid { get { return grid; } }

        public void Draw()
        {
            grid.Draw();
        }

        public void Draw(Grid container)
        {
            grid.Draw(container);
        }

        public void Draw(int x, int y)
        {
            grid.Draw(x, y);
        }

        public void Rotate()
        {
            Square[,] rotatedCells = GenerateShapeCells(type, rotation + 1);
            Grid rotatedGrid = new Grid(grid, rotatedCells);

            if (!CollisionChecker.IsCollision(boardGrid, rotatedGrid))
            {
                grid = rotatedGrid;
                rotation++;
            }
        }

        public void MoveLeft()
        {
            if (!CollisionChecker.IsCollision(boardGrid, grid, -1, 0))
                grid.MoveLeft();
        }

        public void MoveRight()
        {
            if (!CollisionChecker.IsCollision(boardGrid, grid, 1, 0))
                grid.MoveRight();
        }

        public void MoveDown(float speed=1.0f)
        {
            top += speed;

            if ((int)(top + speed) > (int)top)
            {
                if (!CollisionChecker.IsCollision(boardGrid, grid, 0, 1))
                    grid.MoveDown();
                else
                    isDead = true;
            }
        }

        private Square[,] GenerateShapeCells(Type type, int rotation)
        {
            switch (type)
            {
                case Type.I:
                    return ShapeCellsI.Generate(rotation);
                case Type.J:
                    return ShapeCellsJ.Generate(rotation);
                case Type.L:
                    return ShapeCellsL.Generate(rotation);
                case Type.O:
                    return ShapeCellsO.Generate(rotation);
                case Type.S:
                    return ShapeCellsS.Generate(rotation);
                case Type.T:
                    return ShapeCellsT.Generate(rotation);
                case Type.Z:
                    return ShapeCellsZ.Generate(rotation);
            }
            return null;
        }
    }
}