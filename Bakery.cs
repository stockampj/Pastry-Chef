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
            Console.WriteLine("");

            OrderLoop(inventory);
        }

        public static void CreateProducts(BakeryInventory inventory)
        {
            Product bananaBread = new Product("Bannana Bread", (decimal)(3.49), "bread");
            Product ciabatta = new Product("Ciabatta", (decimal)(3.49), "bread");
            Product baguette = new Product("Baguette", (decimal)(3.49), "bread");
            Product doughnut = new Product("Doughnut", (decimal)(1.99), "pastry");
            Product danish = new Product("Danish", (decimal)(1.99), "pastry");
            Product bearClaw = new Product("Bear Claw", (decimal)(1.99), "pastry");
            Product filo = new Product("Filo", (decimal)(1.99), "pastry");

            List<Product> initialList = new List<Product> {bananaBread, ciabatta, doughnut, danish, baguette, bearClaw, filo};
            foreach (Product product in initialList)
            { 
                inventory.AddProduct(product);
            }
        }

        public static void UserOrderUpdate (BakeryInventory inventory)
        {
            Console.WriteLine("Which item would you like to add to your order?");
            string item = Console.ReadLine();
            Console.WriteLine("How many of those do you want?");
            
            int quantity = 0;
            string quantityString = Console.ReadLine();
            if (int.TryParse(quantityString, out quantity))
            {
                inventory.AddItem(item, int.Parse(quantityString));
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

        public static void OrderLoop(BakeryInventory inventory) 
        {
            Console.WriteLine("Would you like to add an item to your order, see the menu or checkout? [shop/menu/checkout]");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "shop":
                    UserOrderUpdate(inventory);
                    UserShoppingCartUpdate(inventory);
                    inventory.CalculateCost();
                    OrderLoop(inventory);
                    break;
                case "menu":
                    inventory.MenuList();
                    OrderLoop(inventory);
                    break;
                case "checkout":
                    Console.WriteLine("Thanks for shopping with us today!");
                    inventory.CalculateCost();
                    break;   
                default:
                    OrderLoop(inventory);
                    break;
            }
        } 
    }
}
