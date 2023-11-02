namespace PowerN
{
    internal class Program
    {
        static long sum = 1;


        static void Main(string[] args)
        {
            int baseNum = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(MyMathPow(baseNum, power));
        }

        static long MyMathPow(int baseNum, int power)
        {
            
            if(power == 0)
            {
                return sum;
            }

            power -= 1;

            sum *= baseNum;

            return MyMathPow(baseNum, power);
        }
    }
}