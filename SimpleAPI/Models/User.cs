using System;
namespace SimpleAPI.Models
{
    public class User
    {
        public User(int id, string login, int typeId, Type type, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.type = type;
            this.typeId = typeId;
        }
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int typeId { get; set; }
        public Type type { get; set; }
    }
}

