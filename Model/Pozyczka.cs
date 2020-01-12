using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundusz2.Model {
    [Table("Pozyczki")]
    public class Pozyczka {
        [Key]
        public Guid Id { get; set; }
        public int NrPozyczki { get; set; }
        public int PostFix { get; set; } // ROK; łącznik dopisywany tylko przy wyswietlaniu //NrPozyczki+PostFix, np.: 1/POZ/2019
        public Uczestnik Pozyczkobiorca { get; set; }
        public DateTime DataWyplaty { get; set; }
        public decimal KwotaCalkowita { get; set; }
        public decimal PozostaloDoSplaty { get; set; }
        public bool Splacona { get; set; }
        public string Uwagi { get; set; }

        //public override string ToString() {
        //    return NrPozyczki+PostFix;
        //}
    }
}
