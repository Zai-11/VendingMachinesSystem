using System;
using VendingMachineSystem;

ProductService productService = new ProductService();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=================================");
    Console.WriteLine("       VENDING MACHINE");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Show Products");
    Console.WriteLine("2. Buy Product");
    Console.WriteLine("3. Exit");
    Console.Write("Please select an option: ");

    string option = Console.ReadLine() ?? "";

    switch (option)
    {
        case "1":
            productService.ShowProducts();
            break;

        case "2":
            productService.BuyProduct();
            break;

        case "3":
            Console.WriteLine("Thank you. Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option. Please enter 1, 2, or 3.");
            break;
    }
}
