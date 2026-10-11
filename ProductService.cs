using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineSystem
{
    public class ProductService
    {
        private readonly List<ProductDto> Products = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Water", Price = 120, Stock = 10 },
            new ProductDto { Id = 2, Name = "Cola", Price = 150, Stock = 8 },
            new ProductDto { Id = 3, Name = "Tea", Price = 140, Stock = 7 },
            new ProductDto { Id = 4, Name = "Chips", Price = 180, Stock = 5 }
        };

        public void ShowProducts()
        {
            Console.WriteLine();
            Console.WriteLine("--------------- PRODUCTS ---------------");
            Console.WriteLine("ID | Name  | Price | Stock");

            foreach (ProductDto product in Products)
            {
                Console.WriteLine($"{product.Id}  | {product.Name,-6} | {product.Price} yen | {product.Stock}");
            }
        }

        public void BuyProduct()
        {
            ShowProducts();

            Console.WriteLine();
            Console.Write("Enter product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }

            ProductDto? product = Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            if (product.Stock <= 0)
            {
                Console.WriteLine("Sorry, this product is out of stock.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Quantity must be a positive number.");
                return;
            }

            if (quantity > product.Stock)
            {
                Console.WriteLine($"Only {product.Stock} item(s) are available.");
                return;
            }

            int total = product.Price * quantity;
            Console.WriteLine($"Total price: {total} yen");
            Console.Write("Enter payment amount (yen): ");

            if (!int.TryParse(Console.ReadLine(), out int payment) || payment < 0)
            {
                Console.WriteLine("Please enter a valid payment amount.");
                return;
            }

            if (payment < total)
            {
                Console.WriteLine($"Not enough money. You need {total - payment} yen more.");
                return;
            }

            int change = payment - total;
            product.Stock -= quantity;

            Console.WriteLine();
            Console.WriteLine("Purchase successful!");
            Console.WriteLine($"Product: {product.Name}");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Total: {total} yen");
            Console.WriteLine($"Payment: {payment} yen");
            Console.WriteLine($"Change: {change} yen");
            Console.WriteLine($"Remaining stock: {product.Stock}");
        }
    }
}
