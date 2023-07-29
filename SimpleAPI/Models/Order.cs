using System;
namespace SimpleAPI.Models
{
    public class Order
    {
        public Order(int id, decimal totalPrice, DateTime orderDate, DateTime orderEndDate, int clientId, Client client, List<Product> products)
        {
            this.id = id;
            this.totalPrice = totalPrice;
            this.orderDate = orderDate;
            this.orderEndDate = orderEndDate;
            this.client = client;
            this.clientId = clientId;
            this.products = products;
        }

        public int id { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime orderEndDate { get; set; }
        public int clientId { get; set; }
        public Client client { get; set; }
        public List<Product> products { get; set; }


    }
}

