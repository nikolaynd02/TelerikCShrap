int[] numbersLengths = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int[][] numbers = new int[2][];

numbers[0] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
numbers[1] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int resultLength = Math.Max(numbersLengths[0],numbersLengths[1]);
int[] result = new int[resultLength];

int shorterNumberLength = Math.Min(numbersLengths[0], numbersLengths[1]);
int longerNumberLength = Math.Max(numbersLengths[0], numbersLengths[1]);

int carryOver = 0;

for(int i = 0; i < shorterNumberLength; i++)
{
    int sum = numbers[0][i] + numbers[1][i] + carryOver;
    carryOver = 0;

    if(sum >= 10)
    {
        carryOver++;
        sum-=10;
    }
    result[i] = sum;
}

int longerNumberIndex = 0;

if (numbers[0].Length <= numbers[1].Length)
{
    longerNumberIndex = 1;
}

for(int i = shorterNumberLength; i < longerNumberLength; i++)
{
    int sum = 0;
    sum += carryOver;
    carryOver = 0;
    sum += numbers[longerNumberIndex][i];

    if(sum >= 10)
    {
        sum-=10;
        carryOver = 1;
    }

    result[i] = sum;
}

Console.WriteLine(string.Join(" ", result));

