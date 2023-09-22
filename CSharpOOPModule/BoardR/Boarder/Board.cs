using System;
using System.Collections.Generic;
using System.Text;
using Boarder.Models;

namespace Boarder
{
    public static class Board
    {
        private static readonly List<BoardItem> Items = new List<BoardItem>();

        public static void AddItem(BoardItem item)
        {
            if (Items.Contains(item))
            {
                throw new InvalidOperationException("item already exists");
            }

            Items.Add(item);
        }

        public static int TotalItems
        {
            get
            {
                return Items.Count;
            }
        }

        public static void LogHistory()
        {
            StringBuilder output = new StringBuilder();

            foreach(BoardItem item in Items)
            {
                output.AppendLine(item.ViewHistory());
            }

            Console.WriteLine(output.ToString());
        }
    }
}
