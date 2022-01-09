namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curieri")]
    public partial class Curieri
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nume_complet { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Parola { get; set; }

        [StringLength(50)]
        public string Locatie { get; set; }

        public int? Telefon { get; set; }

        //public static implicit operator Curieri(Curieri v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
