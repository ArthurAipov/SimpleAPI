using System;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
	public class Settings
	{
        // список типов
        public static List<Models.Type> types = new List<Models.Type>()
        {
            new Models.Type(1, "admin"),
            new Models.Type(2, "client")
        };

        // список пользователей
        public static List<User> users = new List<User>()
        {
          new User(1, "1", 1, types[0], "1"),
          new User(2, "2", 2, types[1], "2"),
          new User(3, "3", 1, types[0], "3"),
          new User(4, "4", 2, types[1], "4"),
          new User(5, "5", 1, types[0], "5"),
          new User(6, "6", 2, types[1], "6")
        };



        public static List<Client> clients = new List<Client>()
        {
            new Client(1, 40, "1", "1", "1", users[2], 2, new List<Order>()),
            new Client(2, 20, "2", "2", "2", users[4], 2, new List<Order>()),
            new Client(3, 16, "3", "3", "3", users[6], 2, new List<Order>()),
        };


        // метод для создания пользователя
        public static bool CreateUser(User user)
        {
            try
            {
                users.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public static bool CreateClient(Client client)
        {
            try
            {
                clients.Add(client);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // метод для удаления пользователя
        public static bool DeleteUser(User user)
        {
            try
            {
                users.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // метод для создания типа
        public static bool CreateType(Models.Type type)
        {
            try
            {
                types.Add(type);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

