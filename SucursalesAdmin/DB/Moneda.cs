using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Moneda
    {
        [key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MonedaId { get;set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Sucursal> Sucursales { get; set; }
    }
}
