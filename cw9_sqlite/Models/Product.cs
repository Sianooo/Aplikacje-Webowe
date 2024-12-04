using System;

namespace cw9_sqlite.Models;

public class Product
{
    //przechowuje 1 rekord z bazy danych
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Type { get; set; }
}
