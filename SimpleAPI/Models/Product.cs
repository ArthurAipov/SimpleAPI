using System;
namespace SimpleAPI.Models
{
    public class Product
    {
        public Product(int id, string name, decimal price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}

