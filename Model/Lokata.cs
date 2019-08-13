using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    [Table("Lokaty")]
    public class Lokata {
        [Key]
        public int Id { get; set; }
        public string NrLokaty { get; set; }
        public string PostFix { get; set; } //NrLokaty+PostFix, np.: 1/LOK/2019
        public string Opis { get; set; }
        public decimal Kwota { get; set; }
        public DateTime DataOtwarcia { get; set; }
        public int IleDni { get; set; }
        public bool Zamknieta { get; set; }
    }
}
