// See https://aka.ms/new-console-template for more information

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010,
        Condition = 4.2
        
    },
    new Product()
    {
        Name = "Hocke   y Stick",
        Price = 12.00M,
        Sold = true,
        StockDate = new DateTime(2023, 11, 21),
        ManufactureYear = 1998,
        Condition = 2.7
    },
    new Product()
    {
        Name = "Boomerang",
        Price = 5.00M,
        Sold = false,
        StockDate = new DateTime(2022, 9, 14),
        ManufactureYear = 1995,
        Condition = 1.9
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 10.00M,
        Sold = false,
        StockDate = new DateTime(2022, 7, 23),
        ManufactureYear = 2022,
        Condition = 4.6
    },
    new Product()
    {
        Name = "Golf Putter",
        Price = 20.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 21),
        ManufactureYear = 2020,
        Condition = 2.5
    },
    new Product()
    {
        Name = "Bike",
        Price = 100.00M,
        Sold = false,
        StockDate = new DateTime(2021, 10, 20),
        ManufactureYear = 1990,
        Condition = 4.6
    }
};

string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
           
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ViewProductDetails()
{

    ListProducts();

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }


    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose:
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {now.Year - chosenProduct.ManufactureYear} years old.
    It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}
    On a scale of 1-5, the condition of the product is {chosenProduct.Condition}.");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    List<Product> latestProducts = new List<Product>();

    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);

    foreach (Product product in products)
    {
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}