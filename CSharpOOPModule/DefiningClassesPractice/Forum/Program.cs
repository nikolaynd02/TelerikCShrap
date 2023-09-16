namespace Forum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ForumPost post1 = new ForumPost("Jane", "What are the benefits of OOP?");
            post1.replies.Add("OOP is faster and easier to execute.");
            post1.replies.Add("OOP provides a clear structure for the programs.");
            post1.replies.Add("OOP makes the code easier to maintain, modify and debug by keeping it DRY.");
            post1.replies.Add("DRY (Do not Repeat Yourself) is a principle about reducing the repetition of code.");

            Console.WriteLine(post1.Format());
        }
    }
}