using System;
using System.Collections.Generic;

namespace Products
{
  public class Product
  {
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public string Type { get; set; }
    public int Count { get; set; }

    public Product (string name, decimal cost, string type)
    {
      Name = name; 
      Cost = cost;
      Type = type;
      Count = 0;
    }
  }

  public class BakeryInventory
  {
    public List<Product> BreadItems {get; set;}
    public List<Product> PastryItems {get; set;}
    
    public BakeryInventory ()
    {
      BreadItems = new List<Product> {};
      PastryItems = new List<Product> {};
    }

    public void AddProduct(Product product)
    {
      if (product.Type == "bread")
      {
        BreadItems.Add(product);
      }
      else if (product.Type == "pastry")
      {
        PastryItems.Add(product);        
      }
      else
      {
        Console.WriteLine("Error: not a Pastry or Bread item");
      }
    }

    public void MenuList()
    {
      Console.WriteLine("");
      Console.WriteLine("==============================");
      Console.WriteLine("");
      Console.WriteLine("        Pierre's Bakery       ");
      Console.WriteLine("");
      Console.WriteLine("           BREAD MENU         ");
      Console.WriteLine("           ==========         ");
      foreach (Product bread in BreadItems)
      {
        Console.WriteLine("      " + bread.Name+ ": $" + bread.Cost);
      }
      Console.WriteLine("");

      Console.WriteLine("           PASTRY MENU        ");
      Console.WriteLine("           ===========        ");
      foreach (Product pastry in PastryItems)
      {
        Console.WriteLine("      " + pastry.Name+ ": $" + pastry.Cost);
      }
      Console.WriteLine("");
      Console.WriteLine("            SPECIALS:         ");
      Console.WriteLine("            =========         ");
      Console.WriteLine("   Buy 2 loaves, get 1 free!  ");
      Console.WriteLine("   Buy 3 pastries for $5.00!  ");
      Console.WriteLine("");
      Console.WriteLine("==============================");
      Console.WriteLine("");
    }
    public void AddItem(string name, int quantity)
    {
      Product orderItem = null;
      for (int i = 0; i < BreadItems.Count; i++)
      {
        if (BreadItems[i].Name.ToLower() == name.ToLower())
        {
          orderItem = BreadItems[i];
        }
      }
      for (int i = 0; i < PastryItems.Count; i++)
      {
        if (PastryItems[i].Name.ToLower() == name.ToLower())
        {
          orderItem = PastryItems[i];
        }
      }
      if (orderItem != null)
      {
        orderItem.Count += quantity;
      } 
      else
      {
        Console.WriteLine("I'm sorry, I couldn't find that item in our shop");
      }
    }
    public void CalculateCost()
    {
      int breadCount = 0;
      int pastryCount = 0;

      foreach (Product product in BreadItems)
      {
        breadCount += product.Count;
      } 
      foreach (Product product in PastryItems)
      {
        pastryCount += product.Count;
      }
      int breadCountDiscount = breadCount - (breadCount/3);
      double breadPrice = (double)breadCountDiscount*3.49;
      double breadSavings = breadCount*3.49 - breadPrice;

      int pastryDiscounter = pastryCount/3;
      double pastryPrice = (double)(pastryDiscounter*5) + (double)(pastryCount%3)*(1.99);
      double pastrySavings = pastryCount*1.99 - pastryPrice; 
      
      double preDiscountPrice = (double)breadCount*3.49 + (double)pastryCount*1.99;
      double totalPrice = pastryPrice + breadPrice;

      Console.WriteLine("               Subtotal: $" + preDiscountPrice);
      if (breadSavings != 0)
      {
        Console.WriteLine(" Bread Special Savings: -$" + breadSavings);
      }
      if (pastrySavings != 0)
      {
        Console.WriteLine("Pastry Special Savings: -$" + pastrySavings);
      }
      Console.WriteLine("");
      Console.WriteLine("          Your Total is: $" + totalPrice);
      Console.WriteLine("");
    }
  }
}