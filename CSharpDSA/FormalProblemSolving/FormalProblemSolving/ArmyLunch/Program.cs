using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSoldiers = int.Parse(Console.ReadLine());
            string[] orderOfArrival = Console.ReadLine().Split().ToArray();

            string[] sergeants = orderOfArrival.Where(x => x[0] == 'S').ToArray();
            string[] corporals = orderOfArrival.Where(x => x[0] == 'C').ToArray();
            string[] privates = orderOfArrival.Where(x => x[0] == 'P').ToArray();


            Console.WriteLine(string.Join(' ', sergeants) + " " + string.Join(' ', corporals) + " " + string.Join(" ", privates));
        }
    }
}