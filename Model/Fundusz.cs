using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundusz2.Model {
    [Table("Fundusz")]
    public class Fundusz {
        [Key]
        public int Id { get; set; }
        public decimal Gotowka { get; set; }
        public decimal Rez2 { get; set; }
        public decimal Rez1 { get; set; }
        // Oprocentowanie w skali roku zmieniane ręcznie (póki co) = Wibor3m + 0,01 (1%); w zaokrągleniu do 0,001 (0,1%)
        public decimal OprocentowaniePozyczek { get; set; }         
        public int MiesiacNaliczeniaOdsetek { get; set; }
    }
}
