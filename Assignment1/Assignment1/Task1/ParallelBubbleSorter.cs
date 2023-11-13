using System;
namespace Assignment1.Task1;

public class ParallelBubbleSorter
{
    internal static int[] GenerateRandomArray(int n)
    {
        Random random = new Random();
        return Enumerable.Range(0, n).Select(x => random.Next(1, 1000)).ToArray();
    }

    internal static int[] ParallelBubbleSort(int[] arr, int threadCount)
    {
        int length = arr.Length;
        int chunkSize = length / threadCount;

        int[][] subArrays = new int[threadCount][];

        for (int i = 0; i < threadCount; i++)
        {
            int startIdx = i * chunkSize;
            int endIdx = (i == threadCount - 1) ? length : startIdx + chunkSize;

            subArrays[i] = new int[endIdx - startIdx];
            Array.Copy(arr, startIdx, subArrays[i], 0, endIdx - startIdx);
        }

        Parallel.For(0, threadCount, i =>
        {
            BubbleSort(subArrays[i]);
        });

        return MergeSortedArrays(subArrays);
    }

    private static void BubbleSort(int[] subArray)
    {
        int temp;
        for (int i = 0; i < subArray.Length - 1; i++)
        {
            for (int j = 0; j < subArray.Length - i - 1; j++)
            {
                if (subArray[j] > subArray[j + 1])
                {
                    temp = subArray[j];
                    subArray[j] = subArray[j + 1];
                    subArray[j + 1] = temp;
                }
            }
        }
    }

    private static int[] MergeSortedArrays(int[][] sortedSubArrays)
    {
        int totalLength = sortedSubArrays.Sum(arr => arr.Length);
        int[] mergedArray = new int[totalLength];
        int[] pointers = new int[sortedSubArrays.Length];

        for (int i = 0; i < totalLength; i++)
        {
            int minVal = int.MaxValue;
            int minIdx = -1;

            for (int j = 0; j < sortedSubArrays.Length; j++)
            {
                if (pointers[j] < sortedSubArrays[j].Length && sortedSubArrays[j][pointers[j]] < minVal)
                {
                    minVal = sortedSubArrays[j][pointers[j]];
                    minIdx = j;
                }
            }

            mergedArray[i] = minVal;
            pointers[minIdx]++;
        }

        return mergedArray;
    }
}

