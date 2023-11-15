using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();


            int startNum = nums[0];
            int count = nums[1];

            List<int> eValues = new List<int>();

            int e = startNum;
            eValues.Add(e);

            int lastValue = e;
            int indexOfE = 0;


            for(int i = 2; i <= count; i++)
            {
                if(i % 3 == 2)
                {
                    lastValue = eValues[indexOfE++ / 3] + 1; 
                }
                else if(i % 3 == 0)
                {
                    lastValue = 2 * eValues[indexOfE++ / 3] + 1;
                }
                else if(i % 3 == 1)
                {
                    lastValue = eValues[indexOfE++ / 3] + 2;
                }

                eValues.Add(lastValue);
            }

            Console.WriteLine(lastValue);
        }
    }
}