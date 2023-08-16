using System;
namespace SimpleAPI.Models
{
	public class UserSettings
	{
        public static List<User> users = new List<User>()
        {
          new User(1, "1", 1, TypeSettings.types[0], "1"),
          new User(2, "2", 2, TypeSettings.types[1], "2"),
          new User(3, "3", 1, TypeSettings.types[0], "3"),
          new User(4, "4", 2, TypeSettings.types[1], "4"),
          new User(5, "5", 1, TypeSettings.types[0], "5"),
          new User(6, "6", 2, TypeSettings.types[1], "6")
        };

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

    }
}

