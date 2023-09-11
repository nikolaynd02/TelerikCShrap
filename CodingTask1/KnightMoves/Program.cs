int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];

// All possible horse moves (8) ordered by priority (top most, left most)

int[][] moves = new int[8][];
moves[0] = new int[] { -2, -1 };
moves[1] = new int[] { -2, 1 };
moves[2] = new int[] { -1, -2 };
moves[3] = new int[] { -1, 2 };
moves[4] = new int[] { 1, -2 };
moves[5] = new int[] { 1, 2 };
moves[6] = new int[] { 2, -1 };
moves[7] = new int[] { 2, 1 };

int movesCounter = 1;
// For each cell in the matrix that is not used try to make horse moves
for (int r = 0; r < n; r++)
{
    for (int c = 0; c < n; c++)
    {
        int currentRow = r;
        int currentCol = c;

        // Make moves while cell is not visited
        while (matrix[currentRow, currentCol] == 0)
        {
            matrix[currentRow, currentCol] = movesCounter;
            movesCounter++;

            // Search for possible move
            for (int move = 0; move < moves.Length; move++)
            {
                int nextRow = currentRow + moves[move][0];
                int nextCol = currentCol + moves[move][1];

                // Check if move goes out of the matrix
                if (nextRow < 0 || nextRow >= matrix.GetLength(0) ||
                        nextCol < 0 || nextCol >= matrix.GetLength(1))
                {
                    continue;
                }

                // Check if the cell is visited
                if (matrix[nextRow, nextCol] != 0)
                {
                    continue;
                }

                currentRow = nextRow;
                currentCol = nextCol;
                break;
            }
        }
    }
}

// Print the output

for (int r = 0; r < matrix.GetLength(0); r++)
{
    for (int c = 0; c < matrix.GetLength(1); c++)
    {
        Console.Write(matrix[r, c]);
        Console.Write(" ");
    }
    Console.WriteLine();
}