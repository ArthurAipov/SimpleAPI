using System;
namespace SimpleAPI.Models
{
    public class TypeSettings
    {

        public static List<Models.Type> types = new List<Models.Type>()
        {
            new Models.Type(1, "admin"),
            new Models.Type(2, "client")
        };


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

