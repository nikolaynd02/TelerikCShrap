using System;

namespace Boarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var issue = new Issue(
       "App flow tests?",
       "We need to test the App!",
       DateTime.Now.AddDays(1));
            Console.WriteLine(issue.Title); // App flow tests?
            Console.WriteLine(issue.Description); // We need to test the App!
            Console.WriteLine(issue.Status); // Open
        }
    }
}
