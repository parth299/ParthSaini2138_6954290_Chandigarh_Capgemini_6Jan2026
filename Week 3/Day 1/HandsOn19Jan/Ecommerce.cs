using System.Collections.Generic;

class EcommerceCustomer
{
    public string Name { get; set; }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

class Electronics : Product { }
class Clothing : Product { }
class Books : Product { }

class Cart
{
    public List<Product> Products = new List<Product>();

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double Total()
    {
        double total = 0;
        foreach (var p in Products)
            total += p.Price;

        return total;
    }
}
