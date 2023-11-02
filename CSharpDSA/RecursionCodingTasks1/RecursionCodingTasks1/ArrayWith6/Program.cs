namespace ArrayWith6
{
    internal class Program
    {
        //static int counter = 0;
        static int target = 6;
        //static bool shouldCheck = false;

        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            int index = int.Parse(Console.ReadLine());

            string result = string.Empty;

            if(CountSixFromIndex(nums, index, 0))
            {
                result = "true";
            }
            else
            {
                result = "false";
            }


            Console.WriteLine(result);
        }

        static bool CountSixFromIndex(int[] nums, int startIndex, int currIndex)
        {
            if(startIndex >= nums.Length)
            {
                return false;
            }

            if(currIndex == nums.Length) 
            { 
                return false;
            }


            if (startIndex <= currIndex && nums[currIndex] == target)
            {
                return true;
            }

            return CountSixFromIndex(nums, startIndex, ++currIndex);
        }
    }
}