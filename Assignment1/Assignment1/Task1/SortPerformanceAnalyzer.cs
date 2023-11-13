using System;
using System.Diagnostics;

namespace Assignment1.Task1;

public class SortPerformanceAnalyzer
{
    internal static void AnalyzePerformance(int arraySize)
    {
        int[] threadCounts = new int[] { 2, 3, 4, 6 };
        int[] originalArray = ParallelBubbleSorter.GenerateRandomArray(arraySize);

        foreach (var threadCount in threadCounts)
        {
            int[] arrayCopy = new int[arraySize];
            Array.Copy(originalArray, arrayCopy, arraySize);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ParallelBubbleSorter.ParallelBubbleSort(arrayCopy, threadCount);

            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Threads: {threadCount}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.ResetColor();
        }
    }
}

