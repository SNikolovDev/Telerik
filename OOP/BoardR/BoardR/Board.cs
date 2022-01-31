using System;
using System.Collections.Generic;

namespace BoardR
{
    public static class Board
    {
        private static List<BoardItem> items = new List<BoardItem>();

        public static int TotalItems { get => items.Count; }

        public static void AddItem(BoardItem item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Item already exists!");
            }
        }
    }
}
