using System;
using SimpleAPI.Models;

namespace SimpleAPI.ModelSettings
{
    public class ProductSettings
    {
        public static List<Product> products = new List<Product>()
        {
            new Product(1, "iphone", 100000),
            new Product(2, "airpods", 15000),
            new Product(3, "macbook", 120000 ),
        };

        public static bool CreateProduct(Product product)
        {
            try
            {
                products.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteProduct(int productId)
        {
            try
            {
                var product = products.FirstOrDefault(x => x.id == productId);
                if (product != null)
                {
                    products.Remove(product);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}

