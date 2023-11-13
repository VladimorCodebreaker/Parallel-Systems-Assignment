using System;
using System.Collections.Concurrent;

namespace Assignment1.Task2;

public class ParallelInventorySearcher
{
    private static readonly object _lockObject = new();

    internal static ConcurrentDictionary<int, ConcurrentBag<string>> SearchInventory(List<Tool> inventory, Dictionary<int, int> targets, int threadCount)
    {
        var foundItems = new ConcurrentDictionary<int, ConcurrentBag<string>>();

        foreach (var target in targets)
        {
            foundItems.TryAdd(target.Key, new ConcurrentBag<string>());
        }

        Parallel.ForEach(inventory, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, tool =>
        {
            if (targets.ContainsKey(tool.Type))
            {
                lock (_lockObject)
                {
                    if (foundItems[tool.Type].Count < targets[tool.Type])
                    {
                        foundItems[tool.Type].Add(tool.Barcode);

                        if (IsSearchComplete(targets, foundItems)) return;
                    }
                }
            }
        });

        return foundItems;
    }

    private static bool IsSearchComplete(Dictionary<int, int> targets, ConcurrentDictionary<int, ConcurrentBag<string>> foundItems)
    {
        foreach (var target in targets)
        {
            if (foundItems[target.Key].Count < target.Value) return false;
        }

        return true;
    }
}

