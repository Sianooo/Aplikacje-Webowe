using cw9_sqlite.Models;

var repo = new ProductsRepo();
var products = repo.GetProducts();

// Display all products
foreach (var product in products)
{
    Console.WriteLine($"{product.Id}\t {product.Name}\t {product.Price}\t {product.Type}");
}

Console.WriteLine("Podaj Id produktu: ");
int id = Convert.ToInt32(Console.ReadLine());
Product? findProduct = repo.GetProductById(id);
if (findProduct != null)
{
    Console.WriteLine($"{findProduct.Id}\t {findProduct.Name}\t {findProduct.Price}\t {findProduct.Type}");
}
else
{
    Console.WriteLine("Brak produktu o podanym id");
}

Console.WriteLine("Podaj nazwę nowego produktu: ");
string name = Console.ReadLine();
Console.WriteLine("Podaj cenę nowego produktu: ");
decimal price = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Podaj typ nowego produktu: ");
string type = Console.ReadLine();

Product product1 = CreateProduct(name, price, type);
repo.AddProduct(product1);

List<Product> productsAfterAdd = repo.GetProducts();
foreach (var product in productsAfterAdd)
{
    Console.WriteLine($"{product.Id}\t {product.Name}\t {product.Price}\t {product.Type}");
}

Product CreateProduct(string name, decimal price, string type)
{
    Product product = new()
    {
        Name = name,
        Price = price,
        Type = type
    };
    return product;
}
