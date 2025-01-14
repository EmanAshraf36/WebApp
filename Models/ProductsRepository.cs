namespace WebApp.Models;

public class ProductsRepository
{
    private static List<Product> _products = new List<Product>()
    {
        new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
        new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
        new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
        new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
    };

    public static void AddProduct(Product product)
    {
        var maxId = _products.Max(x => x.ProductId);
        product.ProductId = maxId + 1;
        _products.Add(product);
    }
    
    public static List<Product> GetProducts() => _products;

    public static Product? GetProductById(int productId)
    {
        var product = _products.FirstOrDefault(x => x.ProductId == productId);
        if (product != null)
        {
            return new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }
        return null;
    }

    public static void deleteProduct(int productId)
    {
        var product = _products.FirstOrDefault(x => x.ProductId == productId);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}

