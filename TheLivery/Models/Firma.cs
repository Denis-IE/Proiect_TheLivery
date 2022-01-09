using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheLivery.Models
{
    public class Firma
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public ICollection<Colet> Colete { get; set; }
    }
}
