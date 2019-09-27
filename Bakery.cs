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
