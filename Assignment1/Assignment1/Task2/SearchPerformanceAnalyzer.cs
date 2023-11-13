using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Assignment1.Task2;

public class SearchPerformanceAnalyzer
{
    internal static void AnalyzePerformance(List<Tool> inventory, Dictionary<int, int> targets, int[] threadCounts)
    {
        foreach (int threadCount in threadCounts)
        {
            // Warm-up phase: run once without measurement to initialize thread pool and JIT
            ParallelInventorySearcher.SearchInventory(inventory, targets, threadCount);

            Stopwatch stopwatch = new Stopwatch();
            double totalMilliseconds = 0;

            for (int run = 0; run < 5; run++)
            {
                stopwatch.Restart();
                ParallelInventorySearcher.SearchInventory(inventory, targets, threadCount);
                stopwatch.Stop();
                totalMilliseconds += stopwatch.Elapsed.TotalMilliseconds;
            }

            double averageTime = totalMilliseconds / 5;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Threads: {threadCount}, Average Time taken: {averageTime} ms");
            Console.ResetColor();

            var foundItems = ParallelInventorySearcher.SearchInventory(inventory, targets, threadCount);
            foreach (var target in targets)
            {
                Console.WriteLine($"Type {target.Key}, Found: {foundItems[target.Key].Count}, Target: {target.Value}");
            }

            Console.WriteLine();
        }
    }
}

