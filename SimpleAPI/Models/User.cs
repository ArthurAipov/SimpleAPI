using System;
namespace SimpleAPI.Models
{
    public class User
    {
        public User(int id, int age, string name, int typeId, Type type)
        {
            this.type = type;
            this.age = age;
            this.name = name;
            this.id = id;
            this.typeId = typeId;
        }
        public int age { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int typeId { get; set; }
        public Type type { get; set; }
    }
}

