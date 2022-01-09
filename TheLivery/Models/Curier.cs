using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLivery.Models
{
    public class Curier
    {
        public int ID { get; set; }
        public string Nume_complet { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        [StringLength(10, ErrorMessage = "Numarul de telefon trebuie sa fie format din 10 cifre!")]
        public string Telefon { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }

    }
}
