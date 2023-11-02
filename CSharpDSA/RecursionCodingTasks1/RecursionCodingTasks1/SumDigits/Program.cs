namespace SumDigits
{
    internal class Program
    {
        static int sum = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(SumDigits(n));
        }

        static int SumDigits(int n)
        {
            int digit = n % 10;

            sum += digit;

            if(n < 10)
            {
                return sum;
            }

            n = (n - digit) / 10;

            return SumDigits(n);



        }

    }
}