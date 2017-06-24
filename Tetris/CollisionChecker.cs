namespace Tetris
{
    public static class CollisionChecker
    {
        public static bool IsCollision(Grid b, Grid s, int deltaLeft=0, int deltaTop=0)
        {
            for (int row = 0; row < s.Rows; row++)
                for (int col = 0; col < s.Columns; col++)
                    if (s.GetCells()[row, col] != null)
                    {
                        if (col + s.Left - b.Left + deltaLeft < 0)
                            return true; //wall collision (left)

                        if (col + s.Left - b.Left + deltaLeft > b.Columns - 1)
                            return true; //wall collision (right)

                        if (row + s.Top - b.Top + deltaTop > b.Rows - 1)
                            return true; //wall collision (bottom)

                        if (row + s.Top - b.Top + deltaTop < 0)
                            continue; //there is no top collision

                        if (b.GetCells()[row + s.Top - b.Top + deltaTop, col + s.Left - b.Left + deltaLeft] != null)
                            return true; //collision between squares
                    }

            return false;
        }
    }
}
