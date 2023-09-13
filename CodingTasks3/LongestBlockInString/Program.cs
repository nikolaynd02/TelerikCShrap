using System.Text;

namespace LongestBlockInString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char maxChar = ' ';
            char currChar = ' ';

            int maxLength = 0;
            int currentLength = 0;

           

            foreach(char c in input)
            {


                if (c == currChar)
                {
                    currentLength++;
                }
                else
                {
                    if(currentLength > maxLength)
                    {
                        maxChar = currChar;
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
                currChar = c;
                
            }

            if (maxChar == currChar)
            {
                currentLength++;
            }
            else
            {
                if (currentLength > maxLength)
                {
                    maxChar = currChar;
                    maxLength = currentLength;
                }
                currentLength = 1;
                currChar = input[input.Length - 1];
            }

            if (maxLength == 0)
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine(new string(maxChar, maxLength));
            }

        }
    }
}