using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundusz2.Model {
    [Table("Inwestycje")]
    public class Inwestycja {
        [Key]
        public Guid Id { get; set; }
        public string NrInwestycji { get; set; }
        public string PostFix { get; set; } //NrInwestycji+PostFix, np.: 1/INW/2019
        public decimal KwotaPoczatkowa { get; set; }
        public string Opis { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public bool Zakonczona { get; set; }
        public decimal KwotaKoncowa { get; set; }
    }
}
