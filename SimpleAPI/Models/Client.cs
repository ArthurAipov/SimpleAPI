using System;
namespace SimpleAPI.Models
{
    public class Client
    {
        public Client(int id, int age, string name, string surename, string patronymic, User user, int userId, List<Order> orders)
        {
            this.id = id;
            this.age = age;
            this.user = user;
            this.userId = userId;
            this.patronymic = patronymic;
            this.surename = surename;
            this.name = name;
            this.orders = orders;
        }

        public int id { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string surename { get; set; }
        public string patronymic { get; set; }
        public User user { get; set; }
        public int userId { get; set; }
        public List<Order> orders = new List<Order>();


    }
}

