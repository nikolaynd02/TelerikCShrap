namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[] sums = new long[n + 1];

            Console.WriteLine(Fibonaci(n, sums));
        }

        static long Fibonaci(long n, long[] sums)
        {
            if (sums[n]  == 0) 
            {
                if(n == 0)
                {
                    return 0;
                }
                if(n == 1)
                {
                    return 1;
                }

                sums[n] = Fibonaci(n - 1, sums) + Fibonaci (n - 2, sums) ;

            }

            return sums[n];
        }
    }
}