using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    [Table("Uczestnicy")]
    public class Uczestnik {
        [Key]
        public Guid Id { get; set; }
        public string ImieNazwisko { get; set; }
        public DateTime DataPrzystapienia { get; set; }
        public decimal Wklad { get; set; }
        public decimal Udzial { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
