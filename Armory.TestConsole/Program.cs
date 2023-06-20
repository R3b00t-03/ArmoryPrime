using Armory.lib;
using Armory.lib.models;

namespace Armory.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DBInterface db = new DBInterface("8CC9143940", "Inventar");
            List<Inventory> inv = db.GetInventoryData();
            foreach (Inventory i in inv)
            {
                Console.WriteLine(i.Artikel);
            }
        }
    }
}