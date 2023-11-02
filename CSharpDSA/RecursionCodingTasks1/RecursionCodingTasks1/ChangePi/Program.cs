namespace ChangePi
{
    internal class Program
    {
        //static int counter = 0;
        static string target = "pi";


        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = 0;

            Console.WriteLine(ChangePi(input, index));
        }

        static string ChangePi(string word, int index)
        {
            if (index + 1 == word.Length)
            {
                return word;
            }
            string temp = word.Substring(index++, 2);


            if (temp == target)
            {
                word = word.Remove(index - 1, 2);
                word = word.Insert(index - 1, "3.14");
            }


            return ChangePi(word, index);

        }
    }
}