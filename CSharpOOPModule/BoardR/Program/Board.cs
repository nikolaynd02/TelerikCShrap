using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Board
    {
        private static List<BoardItem> items;

        static Board()
        {
            items = new List<BoardItem>();
        }

        public static int TotalItems 
        {
            get { return items.Count; }
        }

        public static void AddItem(BoardItem item)
        {
            if(items.Contains(item))
            {
                throw new InvalidOperationException("Item already exists.");
                //return;
            }

            if(item == null)
            {
                return ;
            }

            items.Add(item);
        }



    }
}
