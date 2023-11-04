namespace LargestSurface
{
    internal class Program
    {
        static bool[,] visited;
        static int[,] matrix;
        static int max = 0;
        static int count = 0;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int x = dimensions[0];
            int y = dimensions[1];

            matrix = new int[x, y];
            visited = new bool[x, y];

            for (int i = 0; i < x; i++)
            {
                int[] charsInRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = charsInRow[j];

                }
            }

            for(int i = 0;i < x; i++)
            {
                for(int j = 0;j < y; j++)
                {
                    if (visited[i, j] == false)
                    {
                        DFS(i, j, matrix[i, j]);
                    }
                    if(max <= count)
                    {
                        max = count;
                    }
                    count = 0; ;
                }
            }

            Console.WriteLine(max);
        }

        static void DFS(int x, int y, int target)
        {
            if(x < 0 || y < 0 || x >= matrix.GetLength(0) || y >= matrix.GetLength(1))
            {
                return;
            }  
            if (visited[x, y] == true)
            {
                return;
            }
            if (matrix[x, y] != target)
            {
                return;
            }

            visited[x, y] = true;
            count++;


            DFS(x, y + 1, target);
            DFS(x, y - 1, target);
            DFS(x + 1, y, target);
            DFS(x - 1, y, target);

        }
    }
}