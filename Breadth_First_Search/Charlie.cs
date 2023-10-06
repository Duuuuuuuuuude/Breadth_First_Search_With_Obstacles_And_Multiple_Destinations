namespace BreadthFirst;

class Charlie
{
    private static CellItem _charlie = new(0, 0, 0);
    private static HashSet<CellItem> _eatenFood = new();
    private static int _totalDistance = 0;
    private static int _foodCount = 0;
    private static bool _firstIteration = true;
    private static int _xLength;
    private static int _yLength;

    public static string GetDistanceToNearstFoodItemsAndThenHome(string[] strArr)
    {
        _xLength = strArr.Length;
        _yLength = strArr[0].Length;

        do
        {
            var nearstFood = GetNearstFood(strArr);
            _totalDistance += nearstFood.Distance;
            _charlie = nearstFood;
            _charlie.Distance = 0;
            _foodCount--;
        } while (_foodCount != 0);

        _charlie.Distance = 0;

        _totalDistance += BreadthFirstSearch(new bool[_xLength, _yLength], strArr, true).Distance;

        _charlie = new(0, 0, 0);
        _eatenFood = new();
        _totalDistance = 0;
        _foodCount = 0;
        _firstIteration = true;

        return _totalDistance.ToString();
    }

    public static CellItem GetNearstFood(string[] grid)
    {
        bool[,] visited = new bool[_xLength, _yLength];

        for (int i = 0; i < _xLength; i++)
        {
            for (int j = 0; j < _yLength; j++)
            {
                if (grid[i][j] == 'H')
                {
                    visited[i, j] = true;
                }

                else
                {
                    visited[i, j] = false;
                }

                if (grid[i][j] == 'C' && _firstIteration)
                {
                    _charlie.Row = i;
                    _charlie.Col = j;
                }

                if (grid[i][j] == 'F' && _firstIteration)
                {
                    _foodCount++;
                }
            }
        }
        _firstIteration = false;
        return BreadthFirstSearch(visited, grid, false);
    }

    private static CellItem BreadthFirstSearch(bool[,] visited, string[] grid, bool goingHome)
    {
        Queue<CellItem> pCells = new();
        pCells.Enqueue(_charlie);
        visited[_charlie.Row, _charlie.Col] = true;
        while (pCells.Count > 0 && _foodCount > 0 || goingHome)
        {
            CellItem currentCell = pCells.Dequeue();

            if (goingHome && grid[currentCell.Row][currentCell.Col] == 'H')
            {
                return currentCell;
            }

            if (grid[currentCell.Row][currentCell.Col] == 'F' && _eatenFood.Add(currentCell))
            {
                return currentCell;
            }

            // moving up
            if (currentCell.Row - 1 >= 0 && !visited[currentCell.Row - 1, currentCell.Col])
            {
                pCells.Enqueue(new CellItem(currentCell.Row - 1, currentCell.Col, currentCell.Distance + 1));
                visited[currentCell.Row - 1, currentCell.Col] = true;
            }

            // moving down
            if (currentCell.Row + 1 < _xLength && !visited[currentCell.Row + 1, currentCell.Col])
            {
                pCells.Enqueue(new CellItem(currentCell.Row + 1, currentCell.Col, currentCell.Distance + 1));
                visited[currentCell.Row + 1, currentCell.Col] = true;
            }

            // moving left
            if (currentCell.Col - 1 >= 0 && !visited[currentCell.Row, currentCell.Col - 1])
            {
                pCells.Enqueue(new CellItem(currentCell.Row, currentCell.Col - 1, currentCell.Distance + 1));
                visited[currentCell.Row, currentCell.Col - 1] = true;
            }

            // moving right
            if (currentCell.Col + 1 < _yLength && !visited[currentCell.Row, currentCell.Col + 1])
            {
                pCells.Enqueue(new CellItem(currentCell.Row, currentCell.Col + 1, currentCell.Distance + 1));
                visited[currentCell.Row, currentCell.Col + 1] = true;
            }
        }
        return _charlie;
    }
}