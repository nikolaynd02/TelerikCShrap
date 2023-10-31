namespace StudentsOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int students = nums[0];
            int moves = nums[1];

            List<string> namesOrder = Console.ReadLine().Split().ToList();

            for (int i = 0; i < moves; i++)
            {
                string[] pair = Console.ReadLine().Split().ToArray();

                string mover = pair[0];
                string anchor = pair[1];
                int moverIndex = namesOrder.IndexOf(mover);
                int anchorIndex = namesOrder.IndexOf(anchor);

                namesOrder.Insert(anchorIndex, mover);
                namesOrder.Insert(anchorIndex + 1, anchor);
                namesOrder.Remove(mover);
                namesOrder[anchorIndex] = mover;
                namesOrder[anchorIndex + 1] = anchor;

                
            }

            Console.WriteLine(string.Join(' ', namesOrder));

        }
    }
}