using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
    }

    class Purchase
    {
        public int ItemID { get; set; }
        public int PurchaseQuantity { get; set; }
    }

    static void Main(string[] args)
    {
       
        List<Item> items = new List<Item>
        {
            new Item { ItemID = 1, ItemName = "Biscuit" },
            new Item { ItemID = 2, ItemName = "Chocolate" },
            new Item { ItemID = 3, ItemName = "Butter" },
            new Item { ItemID = 4, ItemName = "Bread" }
        };

        
        List<Purchase> purchases = new List<Purchase>
        {
            new Purchase { ItemID = 3, PurchaseQuantity = 800 },
            new Purchase { ItemID = 5, PurchaseQuantity = 650 },
            new Purchase { ItemID = 3, PurchaseQuantity = 900 },
            new Purchase { ItemID = 4, PurchaseQuantity = 700 },
            new Purchase { ItemID = 3, PurchaseQuantity = 900 },
            new Purchase { ItemID = 4, PurchaseQuantity = 650 },
            new Purchase { ItemID = 1, PurchaseQuantity = 458 }
        };

       
        var rightJoin = from purchase in purchases
                        join item in items on purchase.ItemID equals item.ItemID into gj
                        from subItem in gj.DefaultIfEmpty()
                        select new
                        {
                            ItemID = subItem != null ? subItem.ItemID : purchase.ItemID,
                            ItemName = subItem != null ? subItem.ItemName : null,
                            purchase.PurchaseQuantity
                        };

      
        foreach (var result in rightJoin)
        {
            Console.WriteLine($"{result.ItemID}\t\t{result.ItemName}\t{result.PurchaseQuantity}");
        }

    
    }
}