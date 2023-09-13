namespace Move
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int startIndex = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            int forwardSum = 0;
            int backwardSum = 0;

            while(input != "exit")
            {
                string[] command = input.Split(' ');

                int steps = int.Parse(command[0]);

                bool direction = command[1] == "forward";

                int stepSize = int.Parse(command[2]) % arr.Length;

                if (direction)
                {
                    for(int i = 0; i < steps; i++)
                    {
                        if(startIndex + stepSize >= arr.Length)
                        {
                            startIndex = stepSize - (arr.Length - startIndex);
                            forwardSum += arr[startIndex];
                        }
                        else
                        {
                            startIndex = startIndex + stepSize;
                            forwardSum += arr[startIndex];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < steps; i++)
                    {
                        if (startIndex - stepSize < 0)
                        {
                            startIndex = arr.Length - (Math.Abs(startIndex - stepSize));
                            backwardSum += arr[startIndex];
                        }
                        else
                        {
                            startIndex = startIndex - stepSize;
                            backwardSum += arr[startIndex];
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Forward: {forwardSum}");
            Console.WriteLine($"Backwards: {backwardSum}");
        }
    }
}