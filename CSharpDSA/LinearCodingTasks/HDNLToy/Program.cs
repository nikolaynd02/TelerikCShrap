using System.Text;

namespace HDNLToy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCounter = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            int whitespaceCounter = 0;

            StringBuilder output = new StringBuilder();

            //Fix whitespace formating when printing
            for (int i = 0; i < inputCounter * 2; i++)
            {
                string input = string.Empty;
                int currNumber = 0;
                if(i < inputCounter)
                {
                    input = Console.ReadLine();
                    currNumber = int.Parse(input.Remove(0, 1));
                }

                
                //This will run after half of the for cycle has completed which also means there will be null input
                while(stack.Count > 0 && i >= inputCounter)
                {
                    string closingElement = stack.Pop();
                    whitespaceCounter--;
                    output.AppendLine($"{new string(' ', whitespaceCounter)}</{closingElement}>");
                }

                while (i < inputCounter)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(input);
                        output.AppendLine($"{new string(' ', whitespaceCounter)}<{input}>");
                        whitespaceCounter++;
                        break;
                    }
                    int prevNumber = int.Parse(stack.Peek().Remove(0, 1));

                    if(currNumber > prevNumber)
                    {
                        stack.Push(input);
                        output.AppendLine($"{new string(' ', whitespaceCounter)}<{input}>");
                        whitespaceCounter++;
                        break;
                    }
                    else if(currNumber == prevNumber) 
                    { 
                        string closingElement = stack.Pop();
                        output.AppendLine($"{new string(' ', whitespaceCounter)}</{closingElement}>");
                        stack.Push(input);
                        output.AppendLine($"{new string(' ', whitespaceCounter)}<{input}>");

                        break;

                    }
                    else
                    {
                        string closingElement = stack.Pop();
                        output.AppendLine($"{new string(' ', whitespaceCounter)}</{closingElement}>");
                        whitespaceCounter--;
                        if (i < inputCounter && stack.Count == 0)
                        {
                            stack.Push(input);
                            output.AppendLine($"{new string(' ', whitespaceCounter)}<{input}>");
                            whitespaceCounter++;
                            break;
                        }
                    }
                }
                
            }

            Console.WriteLine( output.ToString() );
        }
    }
}