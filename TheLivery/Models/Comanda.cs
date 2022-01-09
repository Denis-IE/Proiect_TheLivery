using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheLivery.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        [DisplayFormat(NullDisplayText = "Curier nesetat")]
        public int? CurierID { get; set; }
        public int ColetID { get; set; }
        [DisplayFormat(NullDisplayText = "Fara informatii aditionale")]
        public string? Informatii_aditionale { get; set; }
        [DisplayFormat(NullDisplayText = "nepreluat")]
        public string? Stare { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_livrare { get; set; }
        public string AWB { get; set; }
        public Colet Colet { get; set; }
        [DisplayFormat(NullDisplayText = "Curier nesetat")]
        public Curier? Curier { get; set; }
    }
}
