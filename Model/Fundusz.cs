using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundusz2.Model {
    [Table("Fundusz")]
    public class Fundusz {
        [Key]
        public int Id { get; set; }
        public decimal Gotowka { get; set; }
        public decimal Pozyczki { get; set; }
        public decimal Lokaty { get; set; }
        public decimal InneInwestycje { get; set; }
    }
}
