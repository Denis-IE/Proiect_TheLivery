using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLiveryMobile.Models;

namespace TheLiveryMobile.Data
{
    public class ComenziDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public ComenziDatabase(string dPath)
        {
            database = new SQLiteAsyncConnection(dPath);
            database.CreateTableAsync<Firma>().Wait();
            database.CreateTableAsync<Client>().Wait();
            database.CreateTableAsync<Colet>().Wait();
            database.CreateTableAsync<Curier>().Wait();
            database.CreateTableAsync<Comanda>().Wait();  
        }


        public async Task<List<Comanda>> GetComenziAsync()
        {
            var comenzi = await database.Table<Comanda>().ToListAsync();
            if (!comenzi.Any())
            {
                await database.InsertAllAsync(new Firma[]
                {
                    new Firma{Nume="Emag", Adresa="Bucuresti"},
                    new Firma{Nume="Altex", Adresa="Bucuresti/Ilfov"},
                    new Firma{Nume="Media Galaxy", Adresa="Bucuresti/Sect2"},
                    new Firma{Nume="PcGarage", Adresa="Bucuresti/Sect5"}
                });

                await database.InsertAllAsync(new Client[]
                {
                    new Client{Nume_complet="Denis Popan", Adresa="Bucuresti", Nr_telefon="0265925277"},
                    new Client{Nume_complet="Alina Pop", Adresa="Cluj", Nr_telefon="0765925297"},
                    new Client{Nume_complet="Marian Svas", Adresa="Cimisora", Nr_telefon="0775925277"},
                    new Client{Nume_complet="Denis Denar", Adresa="Alba", Nr_telefon="0765927277"}
                });

                await database.InsertAllAsync(new Colet[]
                {
                    new Colet{FirmaId=1, ClientId=1, Greutate=57, Inaltime = 11, Latime = 25, Descriere = "-", Cost = 300},
                    new Colet{FirmaId=2, ClientId=2, Greutate=58, Inaltime = 12, Latime = 26, Descriere = "-",  Cost = 500},
                    new Colet{FirmaId=3, ClientId=3, Greutate=59, Inaltime = 13, Latime = 27, Descriere = "Foarte greu",  Cost = 600},
                    new Colet{FirmaId=4, ClientId=4, Greutate=50, Inaltime = 14, Latime = 28, Descriere = "Foarte mare",  Cost = 700}
                });

                await database.InsertAllAsync(new Curier[]
                {
                    new Curier{Nume_complet="Sorin_curier", Email="curier1@gmail.com", Parola="curier1", Telefon="0257346331"},
                    new Curier{Nume_complet="Vlad_curier", Email="curier2@gmail.com", Parola="curier2", Telefon="0357346331"}
                });

                await database.InsertAllAsync(new Comanda[]
                {
                    new Comanda{CurierId = 1, ColetId = 1, Informatii_aditionale = "", Stare = "In depozitul curierului", Data_livrare = DateTime.UtcNow, AWB = "HbKjgjhgHJGb"},
                    new Comanda{CurierId = 2, ColetId = 2, Informatii_aditionale = "", Stare = "Colet predat curierului", Data_livrare = DateTime.UtcNow, AWB = "LKkjhhVHGhjHJB"},
                    new Comanda{CurierId = 3, ColetId = 3, Informatii_aditionale = "", Stare = "In tranzit", Data_livrare = DateTime.UtcNow, AWB = "ASagaSZsxdDS"},
                    new Comanda{CurierId = 4, ColetId = 4, Informatii_aditionale = "", Stare = "Finalizata", Data_livrare = DateTime.UtcNow, AWB = "mNBVblkmKBHkNjk"}
                });

                return await database.Table<Comanda>().ToListAsync();
            }

            return comenzi;
        }

        public async Task<Comanda> GetComandaAsync(string awb)
        {
            var comanda = await database.Table<Comanda>().Where(x => x.AWB.Equals(awb)).FirstOrDefaultAsync();
            return comanda;
        }
    }
}
