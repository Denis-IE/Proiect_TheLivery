using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiveryMobile.Models
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        [ManyToMany(typeof(Colet))]
        public List<Client> Clienti { get; set; }
    }
}
