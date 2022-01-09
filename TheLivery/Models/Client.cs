using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLivery.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Nume_complet { get; set; }
        public string Adresa { get; set; }
        [StringLength(10, ErrorMessage = "Numarul de telefon trebuie sa fie format din 10 cifre!")]
        public string Nr_telefon { get; set; }
        public ICollection<Colet> Colete { get; set; }
    }
}
