using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [MaxLength(250)]
        public string Descripcion { get; set; }
        [MaxLength(250)]
        public string Direccion { get; set; }
        [MaxLength(250)]
        public string Identificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int MonedaId { get; set; }
        [ ForeignKey("MonedaId")]
        public virtual Moneda Moneda { get; set; }
    }
}
