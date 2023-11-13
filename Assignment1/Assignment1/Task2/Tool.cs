using System;
namespace Assignment1.Task2;

public class Tool
{
    public int Type { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }

    public Tool(int type, string barcode, string description)
    {
        Type = type;
        Barcode = barcode;
        Description = description;
    }
}

