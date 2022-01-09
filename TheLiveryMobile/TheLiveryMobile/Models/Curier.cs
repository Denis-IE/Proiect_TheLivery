using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheLiveryMobile.Models
{
    public class Curier
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nume_complet { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Telefon { get; set; }
        [OneToMany]
        public List<Comanda> Comenzi { get; set; }
    }
}
