using System;

public class InventoryService
{
    private static string[,] products = new string[2, 3]
    {
        { "Apples", "Milk", "Bread" }, 
        { "10", "5", "20" }            
    };

    private static string[,] initialStock = new string[2, 3];

    
    static InventoryService()
    {
        Array.Copy(products, initialStock, products.Length);
    }

    
    public static string[,] GetInventory()
    {
        return products;
    }

    
    public static void UpdateStock(int productIndex, int newQuantity)
    {
        if (productIndex >= 0 && productIndex < products.GetLength(1))
        {
            products[1, productIndex] = newQuantity.ToString();
        }
    }

    
    public static void ResetInventory()
    {
        Array.Copy(initialStock, products, products.Length);
    }
}
