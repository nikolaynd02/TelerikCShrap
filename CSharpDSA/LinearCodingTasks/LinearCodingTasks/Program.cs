using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        if (length == 0)
        {
            Console.WriteLine("No elements");
        }


        Dictionary<int, int> jumbDistances = new Dictionary<int, int>();


        int max = 0;
        int counter = 0;
        int[] result = new int[elements.Length];
        int maxJumps = 0;
        int currentJumps = 0;

        for (int i = 0; i < elements.Length; i++)
        {
            bool isAdded = false;
            
            max = elements[i];
            for (int j = i + 1; j < elements.Length; j++)
            {
                //if (jumbDistances.ContainsKey(j))
                //{
                //    currentJumps += jumbDistances[j];
                //    counter += jumbDistances[j];
                //    break;
                //}              
                //if (!isAdded)
                //{
                //    jumbDistances.Add(i,0);

                //}
                if (max < elements[j])
                {
                    
                    max = elements[j];
                    counter++;
                    currentJumps++;

                    jumbDistances[i]++;
                }
            }
            isAdded = true;
            if (maxJumps < currentJumps)
            {
                maxJumps = currentJumps;
            }
            currentJumps = 0;
            max = 0;
            result[i] = counter;
            counter = 0;
        }
        Console.WriteLine(maxJumps);
        Console.WriteLine(string.Join(" ", result));
    }
}