using System.ComponentModel;

namespace CountOccurrences2
{
    internal class Program
    {
        static int count = 0;
        static int target = 8;
        static bool repeat = false;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CountDigits(n));
        }

        static int CountDigits(int n)
        {
            int digit = n % 10;

            if (digit == target)
            {
                if (repeat)
                {
                    count += 2;

                }
                else
                {
                    count++;
                }
                repeat = true;
            }
            else
            {
                repeat = false; ;
            }

            if (n < 10)
            {
                return count;
            }

            n = (n - digit) / 10;

            return CountDigits(n);



        }
    }
}