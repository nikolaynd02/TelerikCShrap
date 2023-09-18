namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item1 = new BoardItem("Implement login/logout", DateTime.Now.AddDays(3));
            var item2 = new BoardItem("Secure admin endpoints", DateTime.Now.AddDays(5));

            Board.AddItem(item1); // add item1
            Board.AddItem(item2); // add item2
            Board.AddItem(item1); // do nothing - item1 already in the list
            Board.AddItem(item2); // do nothing - item2 already in the list

            int count = Board.TotalItems;
            // count: 2
        }
    }
}