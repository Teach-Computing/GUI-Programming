using LinqApp;
using System;

List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var evenNumbers = numbers.Where(n => n % 2 == 0);

Console.WriteLine("Even Numbers:");
foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}


var squaredNumbers = numbers.Select(n => n * n);

Console.WriteLine("Squared Numbers:");
foreach (var num in squaredNumbers)
{
    Console.WriteLine(num);
}

var sortedNumbers = numbers.OrderByDescending(n => n);

Console.WriteLine("Sorted Numbers (Descending):");
foreach (var num in sortedNumbers)
{
    Console.WriteLine(num);
}


var query = numbers.Where(n => n > 5);
numbers.Add(10);
Console.WriteLine("Numbers greater than 5:");
foreach (var num in query)
{
    Console.WriteLine(num);
}


var products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 1500 },
    new Product { Id = 2, Name = "Mouse", Price = 20 },
    new Product { Id = 3, Name = "Keyboard", Price = 50 },
};

var expensiveProducts = products.Where(p => p.Price > 100);

Console.WriteLine("Expensive Products:");
foreach (var product in expensiveProducts)
{
    Console.WriteLine($"{product.Name}: ${product.Price}");
}


var sum = numbers.Sum();
var average = numbers.Average();

Console.WriteLine($"Sum: {sum}, Average: {average}");



var topProducts = products
    .Where(p => p.Price > 30)
    .OrderBy(p => p.Price)
    .Select(p => p.Name);

Console.WriteLine("Top Products:");
foreach (var name in topProducts)
{
    Console.WriteLine(name);
}




