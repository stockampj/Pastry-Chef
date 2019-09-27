using System;
using System.Collections.Generic;
using Products;

namespace Bakery 
{
    class Program
    {
        static void Main()
        {
            BakeryInventory inventory = new BakeryInventory();
            CreateProducts(inventory);
            inventory.MenuList();
            Console.WriteLine("Welcome to our shop. Take a look at the menu and see if there is anything you'd like.")
            Console.WriteLine("What do want to add to your order?");
            string item = Console.ReadLine();
            Console.WriteLine("How many of thoese do you want?");
            int quantity = Console.ReadLine();
            
            
        }

        public static void CreateProducts(BakeryInventory inventory)
        {
            Product bananaBread = new Product("Bannana Bread", (decimal)(3.25), "bread");
            Product ciabatta = new Product("Ciabatta", (decimal)(3.25), "bread");
            Product doughnut = new Product("Doughnut", (decimal)(1.49), "pastry");
            Product danish = new Product("Danish", (decimal)(1.49), "pastry");

            List<Product> initialList = new List<Product> {bananaBread, ciabatta, doughnut, danish};
            foreach (Product product in initialList)
            { 
                inventory.AddProduct(product);
            }
        }
    }
}
