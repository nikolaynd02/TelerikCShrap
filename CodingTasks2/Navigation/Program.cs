using System.Data.Common;
using System.Numerics;

namespace Navigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int[] targetCells = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger[,] matrix = new BigInteger[rows, columns];
            BigInteger firstRowElement = BigInteger.One;

            for(int i = rows - 1; i >= 0; i--)
            {
                matrix[i, 0] = firstRowElement;
                for(int j = 1; j< columns; j++)
                {
                    matrix[i, j] = matrix[i, j - 1] * 2;
                }
                firstRowElement *= 2;
            }

            int currentRow = rows - 1;
            int currentColumn = 0;
            int coef = Math.Max(rows, columns);
            BigInteger result = BigInteger.Zero;

            foreach(int targetCell in targetCells)
            {
                int targetRow = targetCell / coef;
                int targetColumn = targetCell % coef;

                int horizontalDirection = currentColumn <= targetColumn ? 1 : -1;

                int verticalDirection = currentRow <= targetRow ? 1 : -1;

                for(int i = currentColumn; i != targetColumn; i += horizontalDirection)
                {
                    result += matrix[currentRow, i];
                    matrix[currentRow, i] = BigInteger.Zero;
                }

                for( int i=currentRow; i != targetRow; i += verticalDirection)
                {
                    result += matrix[i, targetColumn];
                    matrix[i, targetColumn] = BigInteger.Zero;
                }

                currentRow = targetRow;
                currentColumn = targetColumn;

            }

            result += matrix[currentRow, currentColumn];

            Console.WriteLine(result);


        }
    }
}