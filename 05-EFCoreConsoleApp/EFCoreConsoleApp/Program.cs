using EFCoreConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        // Ensure database is created
        db.Database.EnsureCreated();

        // Perform CRUD operations
        CreateProduct(db);
        ReadProducts(db);
        UpdateProduct(db);
        DeleteProduct(db);

        // Display final state
        Console.WriteLine("Final list of products:");
        ReadProducts(db);
    }

    static void CreateProduct(AppDbContext db)
    {
        Console.WriteLine("Creating a new product...");
        var product = new Product { Name = "Laptop", Price = 1500.00m };
        db.Products.Add(product);
        db.SaveChanges();
        Console.WriteLine("Product added.");
    }

    static void ReadProducts(AppDbContext db)
    {
        Console.WriteLine("Reading products...");
        var products = db.Products.ToList();
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }
    }

    static void UpdateProduct(AppDbContext db)
    {
        Console.WriteLine("Updating a product...");
        var product = db.Products.FirstOrDefault(p => p.Name == "Laptop");
        if (product != null)
        {
            product.Price = 1400.00m;
            db.SaveChanges();
            Console.WriteLine("Product updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void DeleteProduct(AppDbContext db)
    {
        Console.WriteLine("Deleting a product...");
        var product = db.Products.FirstOrDefault(p => p.Name == "Laptop");
        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
            Console.WriteLine("Product deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}
