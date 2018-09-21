using System;

namespace VisualSorting.Sortings
{
    public class SwappedEventArgs : EventArgs
    {
        public int X { get; }

        public int Y { get; }

        public SwappedEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class ComparedEventArgs : EventArgs
    {
        public int X { get; }

        public int Y { get; }

        public int Result { get; }

        public ComparedEventArgs(int x, int y, int result)
        {
            X = x;
            Y = y;
            Result = result;
        }
    }
}
