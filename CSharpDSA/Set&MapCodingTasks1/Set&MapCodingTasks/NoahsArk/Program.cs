namespace NoahsArk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ark = new Dictionary<string, int>();

            int inputs = int.Parse(Console.ReadLine());

            for(int i = 0; i < inputs; i++)
            {
                string animal = Console.ReadLine();

                if (ark.ContainsKey(animal))
                {
                    ark[animal] += 1;
                }
                else
                {
                    ark.Add(animal, 1);
                }
            }


            foreach(var animal in ark.OrderBy(x => x.Key))
            {
                string isOdd = animal.Value % 2 == 0 ? "Yes" : "No";

                Console.WriteLine($"{animal.Key} {animal.Value} {isOdd}");
            }
        }
    }
}