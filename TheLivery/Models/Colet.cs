using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLivery.Models
{
    public class Colet
    {
        public int ID { get; set; }
        public int FirmaID { get; set; }
        public int ClientID { get; set; }
        public int Greutate { get; set; }
        public int Inaltime { get; set; }
        public int Latime { get; set; }
        [DisplayFormat(NullDisplayText = "Fara descriere")]
        public string? Descriere { get; set; }
        public string Stare { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Cost { get; set; }
        public Firma Firma { get; set; }
        public Client Client { get; set; }
        public Comanda Comanda { get; set; }
    }
}
