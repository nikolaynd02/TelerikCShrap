string input = Console.ReadLine();

List<string> formatedInput = new List<string> (input.Split(' '));


long sum = 0;

for (int i = 0; i < formatedInput.Count; i++)
{
    if (formatedInput[i] == "d")
    {
        sum = 0;
        continue;
    }
    sum += long.Parse(formatedInput[i]);
}

if (sum >= 0)
{
    Console.WriteLine($"happy {sum}");
}
else
{
    Console.WriteLine($"sad {sum}");
}