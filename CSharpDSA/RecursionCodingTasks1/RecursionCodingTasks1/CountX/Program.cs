namespace CountX
{
    internal class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = 0;

            Console.WriteLine(CounterX(input, index));
        }

        static int CounterX(string word, int index)
        {
            if(index == word.Length)
            {
                return counter;
            }

            char symbol = word[index++];

            if(symbol == 'x')
            {
                counter++;
            }


            return CounterX(word, index);

        }
    }
}