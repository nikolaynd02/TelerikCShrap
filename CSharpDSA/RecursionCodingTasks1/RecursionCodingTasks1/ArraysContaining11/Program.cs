namespace ArraysContaining11
{
    internal class Program
    {
        static int counter = 0;
        static int target = 11;
        //static bool shouldCheck = false;

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            int index = int.Parse(Console.ReadLine());

            //string result = string.Empty;



            Console.WriteLine(CountElevenFromIndex(nums,index,0));
        }

        static int CountElevenFromIndex(int[] nums, int startIndex, int currIndex)
        {
            if (startIndex >= nums.Length)
            {
                return 0;
            }

            if (currIndex == nums.Length)
            {
                return counter;
            }


            if (startIndex <= currIndex && nums[currIndex] == target)
            {
                counter++;
            }

            return CountElevenFromIndex(nums, startIndex, ++currIndex);
        }
    }
}