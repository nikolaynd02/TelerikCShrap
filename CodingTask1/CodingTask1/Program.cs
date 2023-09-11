bool isPrime = true;
int n = int.Parse(Console.ReadLine());
for (int i = 1; i <= n; i++)
{
    for (int j = 2; j <= 1024; j++)
    {

        if (i != j && i % j == 0)
        {
            isPrime = false;
            break;
        }

    }
    if (isPrime)
    {
        Console.Write(i + " ");
    }
    isPrime = true;
}
