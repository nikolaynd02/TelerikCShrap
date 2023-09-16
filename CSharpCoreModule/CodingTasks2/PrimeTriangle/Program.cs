using System.Text;

namespace PrimeTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> primeNumbers = new List<int>();

            bool isPrime = true;
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 2; j <= n; j++)
                {

                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
                isPrime = true;
            }

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < primeNumbers.Count; i++)
            {

                for(int j = 1; j <= primeNumbers[i]; j++)
                {
                    if (primeNumbers.Contains(j))
                    {
                        result.Append("1");
                    }
                    else
                    {
                        result.Append("0");
                    }
                }
                result.AppendLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}