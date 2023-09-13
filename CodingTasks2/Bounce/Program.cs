namespace Bounce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int totalRows = dimensions[0];
            int totalCols = dimensions[1];

            long[,] board = GenerateBoard(totalRows, totalCols);

            int currentRow = 0;
            int currentCol = 0;


            //1: down/right; -1: up/left
            int rowDirection = 1;
            int colDirection = 1;

            long result = board[currentRow, currentCol];

            do
            {
                if (totalRows == 1 || totalCols == 1)
                {
                    break;
                }

                int potentialNextRow = currentRow + rowDirection;
                int potentialNextCol = currentCol + colDirection;

                if (potentialNextRow < 0)
                {
                    // we should go down
                    rowDirection = 1;
                }

                if (potentialNextRow >= totalRows)
                {
                    // we should go up
                    rowDirection = -1;
                }

                if (potentialNextCol < 0)
                {
                    // we should go right
                    colDirection = 1;
                }

                if (potentialNextCol >= totalCols)
                {
                    // we should go left
                    colDirection = -1;
                }

                currentRow += rowDirection;
                currentCol += colDirection;

                result += board[currentRow, currentCol];
            } while (!CornerHit(currentRow, currentCol, board));

            Console.WriteLine(result);
        }

        static bool CornerHit(int row, int col, long[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            return (row == 0 && col == 0)               // top left
                || (row == 0 && col == cols - 1)        // top right
                || (row == rows - 1 && col == 0)        // bottom left
                || (row == rows - 1 && col == cols - 1);// bottom right
        }

        static long[,] GenerateBoard(int n, int m)
        {
            long[,] board = new long[n, m];

            long nextRowFirstNumber = 1;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                long currentRowNumber = nextRowFirstNumber;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = currentRowNumber;
                    currentRowNumber *= 2;
                }
                nextRowFirstNumber *= 2;
            }

            return board;
        }
    }
}