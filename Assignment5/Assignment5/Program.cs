using System;
using System.Collections.Generic;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            // TODO: Add 2 items to the inventory
            // Verify the number of items in the inventory.
            Inventory inventory = new Inventory(2);
            inventory.AddItem(new Item("HealthPotion", 1, ItemGroup.Consumable));
            inventory.AddItem(new Item("Helmet", 1, ItemGroup.Equipment));

            
            Console.WriteLine("The number of items in the inventory is: {0}" ,inventory.ListAllItems().Count);
        }
    }
}
