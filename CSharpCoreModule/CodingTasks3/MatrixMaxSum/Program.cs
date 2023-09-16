namespace MatrixMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[i] = new int[row.Length];
                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i][j] = row[j];
                }
            }

            int cols = matrix[0].Length;

            int[] pairs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxSum = int.MinValue;
            for (int i = 0; i < pairs.Length; i += 2)
            {
                int horizontalDirection = pairs[i] > 0 ? 1 : -1;
                int verticalDirection = pairs[i + 1] > 0 ? -1 : 1;

                int row = Math.Abs(pairs[i]) - 1;
                int targetRow = verticalDirection < 0 ? 0 : rows - 1;

                int col = horizontalDirection < 0 ? cols - 1 : 0;
                int targetCol = Math.Abs(pairs[i + 1]) - 1;

                int sum = 0;
                while (col != targetCol)
                {
                    sum += matrix[row][col];
                    col += horizontalDirection;
                }

                while (row != targetRow)
                {
                    sum += matrix[row][col];
                    row += verticalDirection;
                }

                sum += matrix[row][col];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }
      
    }
}