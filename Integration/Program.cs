using System;
using System.Data.SqlClient;
using King.Mapper;
using King.Mapper.Data;

namespace Integration
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Server=localhost;Database=Test;Trusted_Connection=True;");
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Identifier as IdHaha, Name, Type FROM Simple";
            var reader = cmd.ExecuteReader();
     
            var yay = reader.LoadObjects<Yay>();

            foreach (var y in yay)
            {
                Console.WriteLine(string.Format("{0} {1} {2}", y.Identifier, y.Name, y.Type));
            }
            Console.Read();
        }
    }

    public class Yay
    {
        [ActionName(ActionFlags.Load, "IdHaha")]
        public Guid Identifier
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Type
        {
            get;
            set;
        }
    }
}