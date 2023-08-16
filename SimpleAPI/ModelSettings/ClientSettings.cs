using System;
using SimpleAPI.Models;

namespace SimpleAPI.ModelSettings
{
    public class ClientSettings
    {
        public static List<Client> clients = new List<Client>()
        {
            new Client(1, 40, "1", "1", "1", UserSettings.users[1], 2, new List<Product>()),
            new Client(2, 20, "2", "2", "2", UserSettings.users[3], 4, new List<Product>()),
            new Client(3, 16, "3", "3", "3", UserSettings.users[5], 6, new List<Product>()),
        };

        public static bool DeleteClient(Client client)
        {
            try
            {
                clients.Remove(client);
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


    }
}

