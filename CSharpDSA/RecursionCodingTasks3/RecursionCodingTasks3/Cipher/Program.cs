using System.Runtime.InteropServices;
using System.Text;

namespace Cipher
{
    internal class Program
    {
        //this solution os not optimal and gets only 20/100
        static Dictionary<char, string> dic = new Dictionary<char, string>();

        static void Main(string[] args)
        {
            string code = Console.ReadLine();

            string cipher = Console.ReadLine();


            char symbol = ' ';
            char previoussymbol = cipher[0];
            string number = string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                if (previoussymbol != cipher[i] && char.IsLetter(cipher[i]))
                {
                    dic.Add(symbol, number);
                    number = string.Empty;
                    previoussymbol = cipher[i];
                }

                if (char.IsDigit(cipher[i]))
                {
                    number = number + cipher[i];
                }
                else if (char.IsLetter(cipher[i]))
                {
                    symbol = cipher[i];

                }


            }
            dic.Add(symbol, number);

            //StringBuilder output = new StringBuilder();
            List<string> answers = new List<string>();
            int counter = 0;

            for (int i = 1; i <= code.Length; i++)
            {
                var possibleCombs = CombinationsWithRepetition(dic.Keys, i);

                foreach(string c in possibleCombs) 
                {
                    char[] symbols = c.ToCharArray();

                    string currCode = string.Empty;

                    foreach(char s in symbols)
                    {
                        currCode += dic[s];
                    }

                    if(currCode == code)
                    {
                        counter++;
                        //output.AppendLine(c);
                        answers.Add(c);
                    }

                }


        }

        answers = answers.OrderBy(a => a).ToList();

            Console.WriteLine(counter);
            Console.WriteLine(string.Join("\n",answers));



        }

        static IEnumerable<String> CombinationsWithRepetition(IEnumerable<char> input, int length)
        {
            if (length <= 0)
                yield return "";
            else
            {
                foreach (var i in input)
                {
                    foreach (var c in CombinationsWithRepetition(input, length - 1))
                    {
                        yield return i.ToString() + c;
                    }
                }
            }
        }

        //static IEnumerable<IEnumerable<T>> GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        //{
        //    if (length == 1)
        //        return list.Select(t => new T[] { t });

        //    return GetPermutationsWithRept(list, length - 1)
        //        .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        //}
    }
}