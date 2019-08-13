using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    [Table("Pozyczki")]
    public class Pozyczka {
        [Key]
        public int Id { get; set; }
        public string NrPozyczki { get; set; }
        public string PostFix { get; set; } //NrPozyczki+PostFix, np.: 1/POZ/2019
        public Uczestnik Pozyczkobiorca { get; set; }
        public DateTime DataWyplaty { get; set; }
        public decimal KwotaCalkowita { get; set; }
        public decimal PozostaloDoSplaty { get; set; }
        public bool Splacona { get; set; }
    }
}
