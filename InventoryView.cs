using System;

public class InventoryView
{
    
    public static void InventoryView()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Inventory System ===");
            Console.WriteLine("1. View Inventory");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. Reset Inventory");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Display inventory
                    
                    string[,] currentInventory = InventoryService.GetInventory();
                    Console.WriteLine("\nCurrent Inventory:");
                    for (int i = 0; i < currentInventory.GetLength(1); i++)
                    {
                        Console.WriteLine($"{i + 1}. {currentInventory[0, i]} - Stock: {currentInventory[1, i]}");
                    }
                    Pause();
                    break;

                case "2":// Update stock
                    
                    string[,] products = InventoryService.GetInventory();
                    Console.WriteLine("\nSelect a product to update:");
                    for (int i = 0; i < products.GetLength(1); i++)
                    {
                        Console.WriteLine($"{i + 1}. {products[0, i]} - Current Stock: {products[1, i]}");
                    }

                    Console.Write("Enter product number: ");
                    if (int.TryParse(Console.ReadLine(), out int productNumber) &&
                        productNumber >= 1 && productNumber <= products.GetLength(1))
                    {
                        Console.Write("Enter new stock quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int newStock) && newStock >= 0)
                        {
                            InventoryService.UpdateStock(productNumber - 1, newStock);
                            Console.WriteLine("Stock updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid stock quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product selection.");
                    }
                    Pause();
                    break;

                case "3":// Reset inventory
                    
                    InventoryService.ResetInventory();
                    Console.WriteLine("Inventory has been reset to initial stock.");
                    Pause();
                    break;

                case "4": //Exit
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Pause();
                    break;
            }
        }
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
