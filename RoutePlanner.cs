namespace testdome;

internal class RoutePlanner
{
    /*
     * As part of the route planner, the RouteExists method is used as a quick filter if the destination is reachable,
     * before using more computationally intensive procedures for finding the optimal route.
     * 
     * The roads on the map are rasterized and produce a matrix of boolean values - true if the road is present or false if it is not.
     * The roads in the matrix are connected only if the road is immediately left, right below or above it.
     * 
     * Finish the RouteExists method so that it returns true if the destination is reachable or false if it is not.
     * The fromRow and formColumn parameters are the starting row and column in the mapMatrix.
     * The toRow and toColumn are the destination row and column in the mapMatrix. 
     * The mapMatrix parameter is the above mentioned matrix produced from the map.
     * 
     * For example, for the given rasterized map, the code should return true since the destination is reachable: (see RoutePlanner.grid.png)
     * 
     *  |--------------------------------------|
     *  |    ROAD    |  NOT ROAD  |  NOT ROAD  |
     *  |--------------------------------------|
     *  |    ROAD    |    ROAD    |  NOT ROAD  |
     *  |--------------------------------------|
     *  |  NOT ROAD  |    ROAD    |    ROAD    |
     *  |--------------------------------------|
     * 
     *   bool[,] mapMatrix = {
     *        {true, false, false},
     *        {true, true, false},
     *        {false, true, true}
     *   }
     *   
     *   RouteExists(0, 0, 2, 2, mapMatrix); //should return true
     * 
     */
    static int[][] directions = {
        new int[] {-1, 0}, // Up
        new int[] {0, 1},   // Right
        new int[] {1, 0},  // Down
        new int[] {0, -1}, // Left
    };


    static bool IsValidMove(int row, int col, bool[,] mapMatrix)
    {
        bool isInside = row >= 0 && row < mapMatrix.GetLength(0) && col >= 0 && col < mapMatrix.GetLength(1);
        return isInside && mapMatrix[row, col];
    }

    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                         bool[,] mapMatrix)
    {
        bool[,] visited = new bool[mapMatrix.GetLength(0), mapMatrix.GetLength(1)];

        return RouteExists(fromRow, fromColumn, toRow, toColumn, mapMatrix, visited);
    }

    public static bool RouteExists(int fromRow, int fromColumn, int toRow, int toColumn,
                                 bool[,] mapMatrix, bool[,] visited)
    {
        if (fromRow == toRow && fromColumn == toColumn) return true;

        visited[fromRow, fromColumn] = true;


        for (int i = 0; i < directions.Length; i++)
        {
            int newFromRow = fromRow + directions[i][0];
            int newFromColumn = fromColumn + directions[i][1];

            if (IsValidMove(newFromRow, newFromColumn, mapMatrix) && !visited[newFromRow, newFromColumn])
            {
                if (RouteExists(newFromRow, newFromColumn, toRow, toColumn, mapMatrix, visited))
                {
                    return true;
                }

            }
        }


        return false;
    }


    public static string RouteExists()
    {
        bool[,] mapMatrix = {
            {true, true, true},
            {true, true, true},
            {true, true, true}
        };


        string exist = RouteExists(1, 1, 0, 0, mapMatrix) ? "exists." : "does not exist.";
        return $"Route {exist}";
    }
}
