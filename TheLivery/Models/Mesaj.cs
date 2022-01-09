using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheLivery.Models
{
    public class Mesaj
    {
        public int ID { get; set; }
        public string Nume_complet { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }
}
