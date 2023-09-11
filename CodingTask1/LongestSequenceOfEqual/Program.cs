int lines = int.Parse(Console.ReadLine());

int[] nums = new int[lines];

for (int i = 0; i < lines; i++)
{

    nums[i] = int.Parse(Console.ReadLine());
}

int currMaxSequence = 0;
int maxSequence = 0;

int maxLength = 1;
int currentLength = 1;

for (int i = 1; i < lines; i++)
{
    if (nums[i] == nums[i - 1])
    {
        currentLength++;
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
        }
    }
    else
    {
        currentLength = 1;
    }
}

Console.WriteLine(maxLength);
