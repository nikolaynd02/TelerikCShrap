using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScroogeMcDuck
{
    internal class Program
    {
        static int[] currPosition = new int[2]; //x and y
        static int[,] matrix;
        static int coinsCounter = 0;


        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int x = dimensions[0];
            int y = dimensions[1];

            matrix = new int[x, y];


            for (int i = 0; i < x; i++)
            {
                int[] numsInRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = numsInRow[j];

                    if (numsInRow[j] == 0)
                    {
                        currPosition[0] = i;
                        currPosition[1] = j;
                    }
                }
            }



            Traverse(currPosition[0], currPosition[1]);

            Console.WriteLine(coinsCounter);

        }



        //should go to biggest neighboor, if two have same value check order: left, right, up, down
        static void Traverse(int x, int y)
        {
            List<Tile> list = new List<Tile>();

            if (x < 0 || y < 0 || x >= matrix.GetLength(0) || y >= matrix.GetLength(1))
            {
                return;
            }

            if (y - 1 >= 0)
            {
                Tile nextleft = new Tile(matrix[x, y - 1], x, y - 1, 0);
                list.Add(nextleft);

            }

            if (y + 1 < matrix.GetLength(1))
            {
                Tile nextright = new Tile(matrix[x, y + 1], x, y + 1, 1);
                list.Add(nextright);

            }

            if (x - 1 >= 0)
            {
                Tile nextup = new Tile(matrix[x - 1, y], x - 1, y, 2);
                list.Add(nextup);

            }

            if (x + 1 < matrix.GetLength(0))
            {
                Tile nextdown = new Tile(matrix[x + 1, y], x + 1, y, 3);
                list.Add(nextdown);

            }


            if (list.Count == 0)
            {
                return;
            }
            var orderedTiles = list.Where(t => t.Value > 0).OrderByDescending(t => t.Value).ThenBy(t => t.Priority).ToList();
            ;

            if (orderedTiles.Count == 0)
            {
                return;
            }

            var next = orderedTiles[0];

            if (next == null)
            {
                return;
            }


            x = next.Row;
            y = next.Column;

            matrix[x, y] -= 1;
            coinsCounter++;

            Traverse(x, y);



        }
    }

    class Tile
    {
        public Tile(int value, int row, int column, int priority)
        {
            Value = value;
            Row = row;
            Column = column;
            Priority = priority;

        }

        public int Value { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Priority { get; set; }
    }
}