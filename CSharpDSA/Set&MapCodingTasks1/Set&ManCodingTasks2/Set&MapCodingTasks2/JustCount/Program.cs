using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

            int mcsc = 0;//most common symbol counter
            int mclc = 0;//most common lowercase counter
            int mcuc = 0;//most common uppercase counter

            char mcs = (char)127;
            char mcl = (char)127;
            char mcu = (char)127;

            foreach(char symbol in input)
            {
                if (symbolsCount.ContainsKey(symbol))
                {
                    symbolsCount[symbol]++;
                }
                else
                {
                    symbolsCount.Add(symbol, 1);
                }

                int symbolCount = symbolsCount[symbol];

                if (char.IsLower(symbol))
                {
                    //if((int)mcl > (int)symbol)
                    //{
                    //    if(mclc == symbolCount)
                    //    {

                    //    }
                    //}
                    if(mclc == symbolCount && (int)mcl > (int)symbol)
                    {
                        mcl = symbol;
                        mclc = symbolCount;
                    }
                    if(mclc < symbolCount)
                    {
                        mclc = symbolCount;
                        mcl = symbol;
                    }
                }
                else if(char.IsUpper(symbol))
                {
                    if (mcuc == symbolCount && (int)mcu > (int)symbol)
                    {
                        mcu = symbol;
                        mcuc = symbolCount;
                    }
                    if(mcuc < symbolCount)
                    {
                        mcuc = symbolCount;
                        mcu = symbol;
                    }
                }
                else
                {
                    if (mcsc == symbolCount && (int)mcs > (int)symbol)
                    {
                        mcs = symbol;
                        mcsc = symbolCount;
                    }
                    if((mcsc < symbolCount))
                    {
                        mcsc = symbolCount;
                        mcs = symbol;
                    }
                }
            }

            if(mcsc == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine($"{mcs} {mcsc}");
            }
            if (mclc == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine($"{mcl} {mclc}");
            }
            if (mcuc == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine($"{mcu} {mcuc}");
            }

            //Console.WriteLine(input);
        }
    }
}