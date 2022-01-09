using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiveryMobile.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume_complet { get; set; }
        public string Adresa { get; set; }
        public string Nr_telefon { get; set; }
        [ManyToMany(typeof(Colet))]
        public List<Firma> Firme { get; set; }
    }
}
