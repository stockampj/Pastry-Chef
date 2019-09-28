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
            Console.WriteLine("Welcome to our shop. Take a look at the menu and see if there is anything you'd like.");
            
            UserOrderUpdate(inventory);
            UserShoppingCartUpdate(inventory);

            OrderLoop(inventory);




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

        public static void UserOrderUpdate (BakeryInventory inventory)
        {
            Console.WriteLine("Which item would you like to add to your order?");
            string item = Console.ReadLine();
            Console.WriteLine("How many of thoese do you want?");
            string quantity = Console.ReadLine();
            if (quantity != "")
            {
                inventory.AddItem(item, int.Parse(quantity));
            }
            else
            {
                Console.WriteLine("Something went wrong. Let's try again");
                UserOrderUpdate(inventory);
            }
        }

        public static void UserShoppingCartUpdate (BakeryInventory inventory)
        {
            Console.WriteLine("");
            Console.WriteLine("Your Order:");
            Console.WriteLine("");
            foreach (Product product in inventory.BreadItems)
            {
                if (product.Count != 0)
                {
                    Console.WriteLine(product.Count + " " + product.Name);
                }
            }
            foreach (Product product in inventory.PastryItems)
            {
                if (product.Count != 0)
                {
                    Console.WriteLine(product.Count + " " + product.Name);
                }
            }
            Console.WriteLine("");
        }
        public static void LoopChoices (BakeryInventory inventory)
        {
            // Console.WriteLine("Would you like to continue shopping, see the menu or checkout? [shop/menu/checkout]");
            // string userChoice = Console.ReadLine();
            // switch (userChoice)
            // {
            //     case 1:

            // }
            
        }

        public static void OrderLoop(BakeryInventory inventory) 
        {
            Console.WriteLine("Would you like to continue shopping, see the menu or checkout? [shop/menu/checkout]");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "shop":
                    UserOrderUpdate(inventory);
                    UserShoppingCartUpdate(inventory);
                    OrderLoop(inventory);
                    break;
                case "menu":
                    inventory.MenuList();
                    OrderLoop(inventory);
                    break;
                case "checkout":
                    Console.WriteLine("Add checkout stuff");
                    break;   
            }
        } 
    }
}
