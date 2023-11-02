namespace CountOccurrences
{
    internal class Program
    {
        static int count = 0;
        static int target = 7;


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
                count++;
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