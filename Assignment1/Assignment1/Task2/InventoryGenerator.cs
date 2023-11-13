using System;
namespace Assignment1.Task2;

public class InventoryGenerator
{
    private static readonly Random rand = new Random();

    internal static List<Tool> GenerateInventory(int size)
    {
        List<Tool> inventory = new List<Tool>();

        for (int i = 0; i < size; i++)
        {
            int type = rand.Next(1, 101);
            string barcode = Guid.NewGuid().ToString();
            string description = $"Tool Type {type}";
            inventory.Add(new Tool(type, barcode, description));
        }

        return inventory;
    }
}

