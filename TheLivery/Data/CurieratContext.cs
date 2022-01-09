using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheLivery.Models;

namespace TheLivery.Data
{
    public class CurieratContext : DbContext
    {
        public CurieratContext (DbContextOptions<CurieratContext> options)
            : base(options)
        {
        }

        public DbSet<TheLivery.Models.Comanda> Comenzi { get; set; }
        public DbSet<TheLivery.Models.Firma> Firme { get; set; }
        public DbSet<TheLivery.Models.Client> Clienti { get; set; }
        public DbSet<TheLivery.Models.Colet> Colete { get; set; }
        public DbSet<TheLivery.Models.Curier> Curieri { get; set; }
        public DbSet<TheLivery.Models.Mesaj> Mesaje { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>().ToTable("Comanda");
            modelBuilder.Entity<Firma>().ToTable("Firma");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Colet>().ToTable("Colet");
            modelBuilder.Entity<Curier>().ToTable("Curier");
            modelBuilder.Entity<Mesaj>().ToTable("Mesaj");
        }
    }
}
