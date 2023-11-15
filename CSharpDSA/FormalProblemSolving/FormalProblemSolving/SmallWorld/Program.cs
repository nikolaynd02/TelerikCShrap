using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallWorld
{
    class Program
    {
        //private static SortedDictionary<char, int> areas = new SortedDictionary<char, int>();
        private static bool[,] visited;
        private static char[,] matrix;
        static int size = 0;
        static List<int> sizes = new List<int>();
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int height = nums[0];
            int width = nums[1];

            visited = new bool[height, width];
            matrix = new char[height, width];

            for (int x = 0; x < height; x++)
            {
                string input = Console.ReadLine();
                for (int y = 0; y < width; y++)
                {
                    matrix[x, y] = input[y];
                }
            }


            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    if (!visited[x, y])
                    {
                        int chForArea = 1;
                        DFS(x, y);
                        if (size > 0)
                        {
                            sizes.Add(size);
                        }
                        size = 0;
                    }
                }
            }

            Console.WriteLine(string.Join("\n", sizes.OrderByDescending(x => x)));

        }

        

        private static void DFS(int x, int y)
        {
            if (x < 0 || x >= matrix.GetLength(0) || y < 0 || y >= matrix.GetLength(1))
            {
                return;
            }
            if (visited[x, y])
            {
                return;
            }
            if (matrix[x, y] == '0')
            {
                return;
                
            }
            if (matrix[x, y] == '1')
            {
                size++;

            }
            visited[x, y] = true;

            DFS(x, y + 1);
            DFS(x, y - 1);
            DFS(x + 1, y);
            DFS(x - 1, y);
           
        }
    }
}