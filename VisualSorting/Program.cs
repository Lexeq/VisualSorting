using System;
using System.Linq;
using System.Threading;
using VisualSorting.Sortings;

namespace VisualSorting
{
    class Program
    {
        private static int arraySize = 10;

        private static int delay = 250;

        private static Random rnd = new Random();

        private static int[] GetArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(10);
            }
            return array;
        }

        private static int[] ProcessingArray;

        static void Main(string[] args)
        {
            Init();

            VisualSort[] sorts = new VisualSort[]
            {
                new BubbleSort(),
                new CombSort(),
                new InsertionSort(),
                new ShellSort(),
                new SelectionSort(),
                new QuickSort()
            };

            var array = Array.AsReadOnly(GetArray(arraySize));
            Console.WriteLine("Original array:");
            Console.WriteLine(string.Join(" ", array) + Environment.NewLine);
            Console.WriteLine("Press any key to run sortings...\n");
            Console.ReadKey(true);

            foreach (var sort in sorts)
            {
                Console.WriteLine(sort.GetType().Name);
                Subscribe(sort);
                ProcessingArray = array.ToArray();
                sort.Sort(ProcessingArray);
                PrintProcessingArray();
                Console.WriteLine($"\nСomparisons: {sort.CompareCount} Swaps: {sort.SwapCount}\n");
                Unsubscribe(sort);
            }
        }
        private static void Init()
        {
            Console.WriteLine("Enter parameters: [arraySize delay]");
            string[] par = Console.ReadLine().Split();
            if (!(par.Length == 2
                && int.TryParse(par[0], out arraySize)
                && int.TryParse(par[1], out delay)))
            {
                arraySize = 10;
                delay = 300;
            }
            Console.Clear();
            Console.CursorVisible = false;

        }

        private static void Subscribe(VisualSort sorting)
        {
            sorting.Compared += Compared;
            sorting.Swapped += Swapped;
        }

        private static void Unsubscribe(VisualSort sorting)
        {
            sorting.Compared -= Compared;
            sorting.Swapped -= Swapped;
        }

        private static void Swapped(object sender, SwappedEventArgs e)
        {
            PrintProcessingArray(ConsoleColor.Red, e.X, e.Y);
        }

        private static void Compared(object sender, ComparedEventArgs e)
        {
            PrintProcessingArray(ConsoleColor.Green, e.X, e.Y);
        }

        private static void PrintProcessingArray(ConsoleColor specialColor = ConsoleColor.Gray, params int[] specialIndices)
        {
            Console.CursorLeft = 0;
            for (int i = 0; i < ProcessingArray.Length; i++)
            {
                Console.ForegroundColor = Array.IndexOf(specialIndices, i) >= 0 ? specialColor : ConsoleColor.Gray;
                Console.Write(ProcessingArray[i] + " ");
            }
            Thread.Sleep(delay);
        }
    }
}
