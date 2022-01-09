using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiveryMobile.Models
{
    public class Comanda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Curier))]
        public int CurierId { get; set; }
        [ForeignKey(typeof(Colet))]
        public int ColetId { get; set; }
        public string Informatii_aditionale { get; set; }
        public string Stare { get; set; }
        public DateTime Data_livrare { get; set; }
        public string AWB { get; set; }
        [OneToOne]
        public Colet Colet { get; set; }
        [ManyToOne]
        public Curier Curier { get; set; }
    }
}
