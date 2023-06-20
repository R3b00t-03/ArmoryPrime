using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armory.lib.models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Artikel { get; set; } = string.Empty;
        public int Bestand { get; set; }
        public int Mindestbestand { get; set; }
    }
}
