using System.Diagnostics.Metrics;

namespace ArrayValuesTimes10
{
    internal class Program
    {
        static List<long> existingNums = new List<long>();

        static void Main(string[] args)
        {
            long[] nums = Console.ReadLine().Split(',').Select(long.Parse).ToArray();

            long startIndex = long.Parse(Console.ReadLine());

            if(ContainsDevisibleOfTen(nums,startIndex,0))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }

        static bool ContainsDevisibleOfTen(long[] nums, long startIndex, long currIndex)
        {
            if (startIndex >= nums.Length)
            {
                return false;
            }

            if (currIndex == nums.Length)
            {
                return false;
            }

            if(startIndex <= currIndex)
            {
                if (!existingNums.Contains(nums[currIndex]))
                {
                    existingNums.Add(nums[currIndex]);
                }

                if (existingNums.Any(n => n * 10 == nums[currIndex]))
                {
                    return true;
                }
            }




            return ContainsDevisibleOfTen(nums, startIndex, ++currIndex);


        }
    }
}