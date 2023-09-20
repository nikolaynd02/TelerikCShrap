namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
            issue.AdvanceStatus();
            issue.DueDate = issue.DueDate.AddDays(1);
            Console.WriteLine(issue.ViewHistory());
        }
    }
}