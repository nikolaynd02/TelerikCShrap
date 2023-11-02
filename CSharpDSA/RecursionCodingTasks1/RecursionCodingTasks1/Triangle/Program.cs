﻿namespace Triangle
{
    internal class Program
    {
        public static int sum = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CountInc(n));
        }

        public static int CountInc(int n)
        {
            if (n == 0) return sum;

            sum += n;


            return CountInc(n - 1);
        }
    }
}