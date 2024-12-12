using DbApp;
using Microsoft.Data.Sqlite;
using Dapper;

using (var connection = new SqliteConnection("Data Source=MyDatabase.sqlite"))
{
    connection.Open();

    // Create table
    connection.Execute("CREATE TABLE IF NOT EXISTS Person (Id INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT)");

    // Insert data
    connection.Execute("INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)", new { FirstName = "John", LastName = "Doe" });

    // Query data
    var people = connection.Query<Person>("SELECT * FROM Person");

    foreach (var person in people)
    {
        Console.WriteLine($"{person.Id}: {person.FirstName} {person.LastName}");
    }
}