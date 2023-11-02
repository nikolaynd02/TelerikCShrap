namespace BunnyEars2
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

            if(n % 2 == 1)
            {
                sum += 2;
            }
            else
            {
                sum += 3;
            }
            

            return CountInc(n - 1);
        }
    }
}