namespace LongestIncreasingSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxLength = 1;
            int currentLength = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    currentLength++;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
                else
                {
                    currentLength = 1;
                }
            }

            Console.WriteLine(maxLength);
        
        }
    }
}