using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLivery.Models;
namespace TheLivery.Data
{
    public class DbInitializer
    {
        public static void Initialize(CurieratContext context)
        {
            if (context.Comenzi.Any() || context.Colete.Any() || context.Curieri.Any() || context.Clienti.Any() || context.Firme.Any())
            {
                return;
            }

            var firme = new Firma[]
            {
                new Firma{Nume="Emag", Adresa="Bucuresti"},
                new Firma{Nume="Altex", Adresa="Bucuresti/Ilfov"},
                new Firma{Nume="Media Galaxy", Adresa="Bucuresti/Sect2"},
                new Firma{Nume="PcGarage", Adresa="Bucuresti/Sect5"}
            };
            context.Firme.AddRange(firme);
            context.SaveChanges();


            var clienti = new Client[]
            {
                new Client{Nume_complet="Denis Popan", Adresa="Bucuresti", Nr_telefon="0265925277"},
                new Client{Nume_complet="Alina Pop", Adresa="Cluj", Nr_telefon="0765925297"},
                new Client{Nume_complet="Marian Svas", Adresa="Cimisora", Nr_telefon="0775925277"},
                new Client{Nume_complet="Denis Denar", Adresa="Alba", Nr_telefon="0765927277"}
            };
            context.Clienti.AddRange(clienti);
            context.SaveChanges();

            var colete = new Colet[]
            {
                new Colet{FirmaID=1, ClientID=1, Greutate=57, Inaltime = 11, Latime = 25, Stare = "Nepreluat", Cost = 300},
                new Colet{FirmaID=2, ClientID=2, Greutate=58, Inaltime = 12, Latime = 26, Stare = "Nepreluat", Cost = 500},
                new Colet{FirmaID=3, ClientID=3, Greutate=59, Inaltime = 13, Latime = 27, Stare = "Nepreluat", Cost = 600},
                new Colet{FirmaID=4, ClientID=4, Greutate=50, Inaltime = 14, Latime = 28, Stare = "Nepreluat", Cost = 700}
            };
            context.Colete.AddRange(colete);
            context.SaveChanges();

            var curieri = new Curier[]
            {
                new Curier{Nume_complet="Sefu la curieri", Email="curier1@gmail.com", Parola="fraierilor", Telefon="0257346331"},
                new Curier{Nume_complet="Curier2", Email="curier2@gmail.com", Parola="curier2", Telefon="0357346331"}
            };
            context.Curieri.AddRange(curieri);
            context.SaveChanges();
        }

    }
}
