using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiveryMobile.Models
{
    public class Colet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Firma))]
        public int FirmaId { get; set; }
        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        public int Greutate { get; set; }
        public int Inaltime { get; set; }
        public int Latime { get; set; }
        public string Descriere { get; set; }
        public decimal Cost { get; set; }
    }
}
