using System;
using SimpleAPI.Models;

namespace SimpleAPI.ModelSettings
{
    public class OrderSettings
    {
        public static List<Order> orders = new List<Order>();

        public static bool CreateOrder(Client client, List<Product> products)
        {
            try
            {
                var ordersCount = orders.Count;
                var date = DateTime.Now.Date;
                var endDate = date.AddDays(10);
                var orderId = 0;
                decimal totalPrice = 0;
                foreach (var product in products)
                {
                    totalPrice += product.price;
                }
                if (ordersCount == 0)
                    orderId = 1;
                else
                    orderId = ordersCount + 1;
                var newOrder = new Order(orderId, totalPrice, date, endDate, client.id, client, products, StatusSettings.statuses[2], 3);
                orders.Add(newOrder);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}

