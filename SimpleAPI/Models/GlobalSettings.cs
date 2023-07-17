using System;
namespace SimpleAPI.Models
{

    public class GlobalSettings
    {
        // список типов
        public static List<Type> types = new List<Type>()
        {
            new Type(1, "admin"),
            new Type(2, "client")
        };

        // список пользователей
        public static List<User> users = new List<User>()
        {
           new User(1, 16, "Aipov Arthur", 1, types[0]),
           new User(2, 38, "Aipov Timur", 1, types[0]),
           new User(3, 17, "Pichalnikova Anna", 2, types[1]),
           new User(4, 17, "Alexander Sivkov", 1, types[0]),
           new User(5, 20, "Daniil Shchepkin", 2, types[1])
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
        public static bool CreateType(Type type)
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


