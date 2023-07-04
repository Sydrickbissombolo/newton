using System;
using System.Collections.Generic;

public class InventoryItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class InventoryManagement : List<InventoryItem>
{
    public void AddItem(InventoryItem item)
    {
        this.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        this.Remove(item);
    }

    public void DisplayInventory()
    {
        foreach (var item in this)
        {
            Console.WriteLine($"Item: {item.Name}, Price: {item.Price}");
        }
    }
}
