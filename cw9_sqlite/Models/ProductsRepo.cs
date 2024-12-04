using System;
using Microsoft.Data.Sqlite;

namespace cw9_sqlite.Models;

public class ProductsRepo
{
    private readonly string? _connString;
    
    public ProductsRepo()
    {
        _connString = "Data Source=ProductsDb.db";
    }

    // Method to get all products
    public List<Product> GetProducts()
    {
        List<Product> products = new();
        using (SqliteConnection connection = new(_connString))
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM products";
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(
                        new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Type = reader.GetString(3)
                        }
                    );
                }
            }
        }
        return products;
    }

    // Method to get a product by ID
    public Product? GetProductById(int id)
    {
        Product? product = null;
        using (SqliteConnection connection = new(_connString))
        {
            SqliteCommand command = connection.CreateCommand();
            // command.CommandText=$"SELECT * FROM products WHERE Id = {id}";
            command.CommandText = "SELECT * FROM products WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    product = new Product
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        Type = reader.GetString(3)
                    };
                }
            }
        }
        return product;
    }
    public void AddProduct(Product product)
    {
        using (SqliteConnection connection = new(_connString))
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO products (Name, Price, Type) VALUES (@name, @price, @type)";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@type", product.Type);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
