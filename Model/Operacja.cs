using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    [Table("Operacje")]
    public class Operacja {
        [Key]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TypOperacji Typ { get; set; }
        public string Opis { get; set; }
        public decimal Kwota { get; set; }
        public string NrElementuOperacji { get; set; }
        //public decimal IloscGotowkiPoOperacji { get; set; }

        public enum TypOperacji {
            FunduszZalozycielski,
            OdsetkiPozyczki,
            SplataPozyczki,
            PrzychodZLokaty,
            PrzychodInny,
            WyplataPozyczki,
            RozchodNaLokate,
            RozchodInny
        };
    }
}
