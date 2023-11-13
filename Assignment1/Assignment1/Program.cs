using Assignment1.Task1;
using Assignment1.Task2;

namespace Assignment1;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==== Assignment 1 ====");
            Console.ResetColor();

            Console.WriteLine("\nPlease select an option:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Run Parallel Bubble Sort Task");
            Console.WriteLine("2. Run Parallel Inventory Search Task");
            Console.WriteLine("3. Run Both Tasks");
            Console.WriteLine("0. Exit");
            Console.ResetColor();

            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nStarting Task 1: Parallel Bubble Sort\n");
                    Console.ResetColor();
                    SortPerformanceAnalyzer.AnalyzePerformance(100000);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nStarting Task 2: Parallel Inventory Search\n");
                    Console.ResetColor();

                    List<Tool> inventory = InventoryGenerator.GenerateInventory(100000);

                    Dictionary<int, int> targets = new Dictionary<int, int>
                        {
                            { 1, 30 },
                            { 7, 15 },
                            { 10, 8 }
                        };

                    int[] threadCounts = new int[] { 2, 3, 4, 6 };

                    SearchPerformanceAnalyzer.AnalyzePerformance(inventory, targets, threadCounts);

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nStarting Both Tasks");
                    Console.ResetColor();

                    Console.WriteLine("\nTask 1: Parallel Bubble Sort\n");
                    SortPerformanceAnalyzer.AnalyzePerformance(100000);

                    Console.WriteLine("\nTask 2: Parallel Inventory Search\n");
                    inventory = InventoryGenerator.GenerateInventory(100000);

                    targets = new Dictionary<int, int>
                        {
                            { 1, 30 },
                            { 7, 15 },
                            { 10, 8 }
                        };

                    threadCounts = new int[] { 2, 3, 4, 6 };

                    SearchPerformanceAnalyzer.AnalyzePerformance(inventory, targets, threadCounts);

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nExiting program. Goodbye! <3 ꒰ᐢ. .ᐢ꒱₊˚⊹ ");
                    Console.ResetColor();
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }
    }
}

