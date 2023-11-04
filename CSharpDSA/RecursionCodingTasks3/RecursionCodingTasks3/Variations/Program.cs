using System.Text;

namespace Variations
{
    internal class Program
    {
       static  StringBuilder output = new StringBuilder();

        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            char[] chars = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            char first = chars[0] > chars[1] ? chars[1] : chars[0];
            char second = chars[0] < chars[1] ? chars[1] : chars[0];

            char[] word = new char[length];

            GenerateAllBinaryCombinations(length ,word,0, first, second);

            Console.WriteLine(output.ToString());
            
        }


        static void GenerateAllBinaryCombinations(int length,
                            char[] arr, int iteration , char first, char second)
        {
            if (iteration == length)
            {
                output.AppendLine(string.Join("", arr));
                return;
            }
            
            arr[iteration] = first;
            GenerateAllBinaryCombinations(length, arr, iteration + 1, first, second);

            arr[iteration] = second;
            GenerateAllBinaryCombinations(length, arr, iteration + 1, first, second);
        }

    }
}