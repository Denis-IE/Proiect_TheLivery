using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AutoLotModel
{
    public partial class AutoLotEntitiesModel : DbContext
    {
        public AutoLotEntitiesModel()
            : base("name=AutoLotEntitiesModel")
        {
        }

        public virtual DbSet<Curieri> Curieris { get; set; }
        public virtual DbSet<Firma> Firmas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curieri>()
                .Property(e => e.Nume_complet)
                .IsUnicode(false);

            modelBuilder.Entity<Curieri>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Curieri>()
                .Property(e => e.Parola)
                .IsUnicode(false);

            modelBuilder.Entity<Curieri>()
                .Property(e => e.Locatie)
                .IsUnicode(false);

            modelBuilder.Entity<Firma>()
                .Property(e => e.Nume)
                .IsUnicode(false);

            modelBuilder.Entity<Firma>()
                .Property(e => e.Adresa)
                .IsUnicode(false);
        }
    }
}
