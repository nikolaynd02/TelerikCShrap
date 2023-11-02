namespace CountHi
{
    internal class Program
    {
        static int counter = 0;
        static string target = "hi"; 


        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = 0;

            Console.WriteLine(CounterX(input, index));
        }

        static int CounterX(string word, int index)
        {
            if (index + 1 == word.Length)
            {
                return counter;
            }
            string temp = word.Substring(index++, 2);


            if (temp == target)
            {
                counter++;
            }


            return CounterX(word, index);

        }
    }
}