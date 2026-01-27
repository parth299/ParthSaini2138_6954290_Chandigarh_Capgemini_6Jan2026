using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> inventory = new List<Book>
            {
                new Book("Clean Code", 30.00m, 5),
                new Book("The Pragmatic Programmer", 45.00m, 0),
                new Book("C# in Depth", 40.00m, 3),
                new Book("Design Patterns", 55.00m, 2)
            };

            Console.WriteLine("=== Initial Inventory ===");
            DisplayInventory(inventory);

            inventory.Add(new Book("Refactoring", 35.00m, 4));

            DisplayInventory(inventory);

            decimal targetPrice = 40.00m;

            var cheapBooks = inventory
                .Where(book => book.Price < targetPrice)
                .ToList();

            Console.WriteLine($"\n=== Books Cheaper Than ${targetPrice} ===");
            DisplayInventory(cheapBooks);

            decimal increasePercentage = 10m; 

            inventory.ForEach(book =>
                book.Price += book.Price * increasePercentage / 100
            );

            Console.WriteLine($"\n=== After {increasePercentage}% Price Increase ===");
            DisplayInventory(inventory);

            inventory = inventory
                .Where(book => book.Quantity > 0)
                .ToList();

            Console.WriteLine("\n=== After Removing Out-of-Stock Books ===");
            DisplayInventory(inventory);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayInventory(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Book(string title, decimal price, int quantity)
        {
            Title = title;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Price: ${Price:F2}, Quantity: {Quantity}";
        }
    }
}
